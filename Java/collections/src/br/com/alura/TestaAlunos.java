package br.com.alura;

import java.util.HashSet;
import java.util.Set;

public class TestaAlunos {
	public static void main(String[] args) {
		Set<String> alunos = new HashSet<String>();
		
		alunos.add("Rodrigo Turini");
		alunos.add("Alberto Souza");
		alunos.add("Nico Stepat");
		alunos.add("Sergio Lopes");
		alunos.add("Renan Saggio");
		alunos.add("Mauricio Aniche");
		boolean adicionou = alunos.add("Alberto Souza");
		
		System.out.println(alunos.size());
		
		for (String aluno : alunos) {
			System.out.println(aluno);
		}
		System.out.println();
		
		System.out.println(alunos.contains("Mario Junior"));
		alunos.remove("Sergio Lopes");
		System.out.println("adicionou " + adicionou);
		alunos.forEach(aluno -> System.out.println(aluno));
		System.out.println(alunos);
	}
}
