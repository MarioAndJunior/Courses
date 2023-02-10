package br.com.alura.escola.academico.infra.aluno;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import br.com.alura.escola.academico.dominio.aluno.Aluno;
import br.com.alura.escola.academico.dominio.aluno.CPF;
import br.com.alura.escola.academico.dominio.aluno.Email;
import br.com.alura.escola.academico.dominio.aluno.RepositorioDeAlunos;
import br.com.alura.escola.academico.dominio.aluno.Telefone;
import br.com.alura.escola.academico.dominio.aluno.ValorMaximoDeCadatroExcedido;

public class RepositorioDeAlunosComJDBC implements RepositorioDeAlunos {
	
	private final Connection connection;
	
	public RepositorioDeAlunosComJDBC(Connection connection) {
		this.connection = connection;
	}

	@Override
	public void matricular(Aluno aluno) {
		try {
			String sql = "INSERT INTO ALUNO VALUES(?, ?, ?)";
			PreparedStatement ps = connection.prepareStatement(sql);
			
			ps.setString(1, aluno.getCpf().getNumero());
			ps.setString(2, aluno.getNome());
			ps.setString(3, aluno.getEmail().getEndereco());
			ps.execute();
			
			sql = "INSERT INTO TELEFONE VALUES(?, ?)";
			ps = connection.prepareStatement(sql);
			
			for (Telefone telefone: aluno.getTelefones()) {
				ps.setString(1, telefone.getDdd());
				ps.setString(2, telefone.getNumero());
				ps.execute();
			}
		} catch (SQLException e) {
			throw new RuntimeException(e);
		}

	}

	@Override
	public Aluno buscarPorCPF(CPF cpf) {
		try {
			
			String sql = "SELECT id, nome, email FROM ALUNO WHERE cpf = ?";
			PreparedStatement ps;
			ps = connection.prepareStatement(sql);
			ps.setString(1, cpf.getNumero());
			ResultSet result = ps.executeQuery();
			
			boolean encontrou = result.next();
			if (!encontrou) {
				throw new AlunoNaoEncontrado(cpf);
			}
			
			String nome = result.getString("nome");
			Email email = new Email(result.getString("email"));
			Aluno encontrado = new Aluno(cpf, nome, email);
			
			Long id = result.getLong("id");
			sql = "SELECT ddd, numero FROM TELEFONE WHERE aluno = ?";
			ps = connection.prepareStatement(sql);
			ps.setLong(1, id);
			result = ps.executeQuery();
			
			while (result.next()) {
				String numero = result.getString("numero");
				String ddd = result.getString("ddd");
				try {
					encontrado.adicionarTelefone(ddd, numero);
				} catch (ValorMaximoDeCadatroExcedido e) {
					throw new RuntimeException(e.getMessage());
				}
			}
			
			return encontrado;
		} catch (SQLException | AlunoNaoEncontrado e) {
			throw new RuntimeException(e);
		}
	}

	@Override
	public List<Aluno> listarTodosAlunosMatriculados() {
		List<Aluno> alunos = new ArrayList<Aluno>();
		try {
			String sql = "SELECT id, cpf, nome, email FROM ALUNO";
			PreparedStatement ps = connection.prepareStatement(sql);
			ResultSet result = ps.executeQuery();
			
			while (result.next()) {
				CPF cpf = new CPF(result.getString("cpf"));
				String nome = result.getString("nome");
				Email email = new Email(result.getString("email"));
				Aluno encontrado = new Aluno(cpf, nome, email);
				
				Long id = result.getLong("id");
				sql = "SELECT ddd, numero FROM TELEFONE WHERE aluno_id = ?";
				ps = connection.prepareStatement(sql);
				ps.setLong(1, id);
				ResultSet telefones = ps.executeQuery();
				
				while (telefones.next()) {
					String numero = telefones.getString("numero");
					String ddd = telefones.getString("ddd");
					try {
						encontrado.adicionarTelefone(ddd, numero);
					} catch (ValorMaximoDeCadatroExcedido e) {
						throw new RuntimeException(e.getMessage());
					}
				}
				alunos.add(encontrado);
			}
			
			return alunos;
		} catch (SQLException e) {
			throw new RuntimeException(e);
		}
	}
}
