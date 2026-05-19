package com.mariojunior.exercicios;

import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import tools.jackson.databind.ObjectMapper;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.*;
import java.util.stream.Collectors;

@FunctionalInterface
interface OperacaoMatematica {
	int executar(int num1, int num2);
}

@FunctionalInterface
interface NumeroPrimo{
	boolean isPrimo(int num);
}

@FunctionalInterface
interface UpperChars {
	String toUpper(String string);
}

@FunctionalInterface
interface Palindromo {
	boolean isPalindromo(String string);
}

@FunctionalInterface
interface Divisor {
	int dividir(int a, int b) throws ArithmeticException;
}

@SpringBootApplication
public class ExerciciosApplication implements CommandLineRunner {

	public static void main(String[] args) {
		SpringApplication.run(ExerciciosApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		//lerDigito();
		//jsonArquivo();
		//lambdas();
		//brincandoComStreams();
		//streamParalela();

		List<Integer> numeros = Arrays.asList(10, 20, 30, 40, 50);
		IntSummaryStatistics collect = numeros.stream()
				.collect(Collectors.summarizingInt(n -> n));

		System.out.println("Maior: " + collect.getMax());

		List<String> palavras = Arrays.asList("java", "stream", "lambda", "code");
		var agrupamento = palavras.stream()
				.collect(Collectors.groupingBy(String::length));

		System.out.println(agrupamento);

		List<String> nomes = Arrays.asList("Alice", "Bob", "Charlie");
		String resultado = nomes.stream()
				.collect(Collectors.joining(", "));
		System.out.println(resultado);

		List<Integer> numeros1 = Arrays.asList(1, 2, 3, 4, 5, 6);
		int somaDosQuadrados = numeros1.stream()
				.filter(n -> n % 2 == 0)
				.map(n -> n * n)
				.reduce(0, Integer::sum);
		System.out.println(somaDosQuadrados); // Esperado: 56 (4 + 16 + 36)

		List<Integer> numeros2 = Arrays.asList(1, 2, 3, 4, 5, 6);
		Map<Boolean, List<Integer>> particionado = numeros2.stream()
				.collect(Collectors.partitioningBy(n -> n % 2 == 0));
		System.out.println("Pares: " + particionado.get(true));  // Esperado: [2, 4, 6]
		System.out.println("Ímpares: " + particionado.get(false)); // Esperado: [1, 3, 5]

		List<Produto> produtos = Arrays.asList(
				new Produto("Smartphone", 800.0, "Eletrônicos"),
				new Produto("Notebook", 1500.0, "Eletrônicos"),
				new Produto("Mesa", 700.0, "Móveis"),
				new Produto("Cadeira", 300.0, "Móveis"),
				new Produto("Fone de Ouvido", 100.0, "Eletrônicos"),
				new Produto("Caneta", 5.0, "Papelaria")
		);

		Map<String, List<Produto>> produtosPorCategoria = produtos.stream()
				.collect(Collectors.groupingBy(Produto::getCategoria));

		System.out.println(produtosPorCategoria);

		List<Produto> produtos2 = Arrays.asList(
				new Produto("Smartphone", 800.0, "Eletrônicos"),
				new Produto("Notebook", 1500.0, "Eletrônicos"),
				new Produto("Mesa", 700.0, "Móveis"),
				new Produto("Cadeira", 300.0, "Móveis"),
				new Produto("Fone de Ouvido", 100.0, "Eletrônicos"),
				new Produto("Caneta", 5.0, "Papelaria")
		);

		Map<String, Long> contagemPorCategoria = produtos2.stream()
				.collect(Collectors.groupingBy(Produto::getCategoria, Collectors.counting()));

		System.out.println(contagemPorCategoria);

		List<Produto> produtos3 = Arrays.asList(
				new Produto("Smartphone", 800.0, "Eletrônicos"),
				new Produto("Notebook", 1500.0, "Eletrônicos"),
				new Produto("Mesa", 700.0, "Móveis"),
				new Produto("Cadeira", 300.0, "Móveis"),
				new Produto("Fone de Ouvido", 100.0, "Eletrônicos"),
				new Produto("Caneta", 5.0, "Papelaria")
		);

		Map<String, Optional<Produto>> maisCaroPorCategoria = produtos3.stream()
				.collect(Collectors.groupingBy(Produto::getCategoria,
						Collectors.maxBy(Comparator.comparingDouble(Produto::getPreco))));

		System.out.println(maisCaroPorCategoria);

		List<Produto> produtos4 = Arrays.asList(
				new Produto("Smartphone", 800.0, "Eletrônicos"),
				new Produto("Notebook", 1500.0, "Eletrônicos"),
				new Produto("Mesa", 700.0, "Móveis"),
				new Produto("Cadeira", 300.0, "Móveis"),
				new Produto("Fone de Ouvido", 100.0, "Eletrônicos"),
				new Produto("Caneta", 5.0, "Papelaria")
		);

		Map<String, Double> somaPrecoPorCategoria = produtos4.stream()
				.collect(Collectors.groupingBy(Produto::getCategoria,
						Collectors.summingDouble(Produto::getPreco)));

		System.out.println(somaPrecoPorCategoria);
	}

	private static void streamParalela() {
		List<Integer> numeros = new ArrayList<>();
		for (int i = 1; i <= 100; i++) {
			numeros.add(i);
		}
		Optional<Integer> numeroQualquer = numeros.parallelStream()
				.peek(n -> System.out.println("filter "+ n + " " + Thread.currentThread().getId()))
				.filter(numero -> numero % 10 == 0)
				.peek(n -> System.out.println("find "+n))
				.findAny();

		if (numeroQualquer.isPresent()) {
			System.out.println("Encontrado: " + numeroQualquer.get());
		} else {
			System.out.println("Nenhum número encontrado.");
		}
	}

	private static void brincandoComStreams() {
		List<Integer> numeros = Arrays.asList(1, 2, 3, 4, 5, 6);
		numeros.stream()
				.filter(numero -> numero % 2 == 0)
				.forEach(System.out::println);

		List<String> palavras = Arrays.asList("java", "stream", "lambda");
		palavras.stream()
				.map(String::toUpperCase)
				.forEach(System.out::println);

		List<Integer> alterados = numeros.stream()
				.filter(numero -> numero % 2 != 0)
				.map(numero -> numero * 2)
				.collect(Collectors.toList());

		alterados.forEach(System.out::println);

		List<String> frutas = Arrays.asList("apple", "banana", "apple", "orange", "banana");
		frutas.stream()
				.distinct().forEach(System.out::println);


		List<List<Integer>> listaDeNumeros = Arrays.asList(
				Arrays.asList(1, 2, 3, 4),
				Arrays.asList(5, 6, 7, 8),
				Arrays.asList(9, 10, 11, 12)
		);

		List<Integer> subListas = listaDeNumeros.stream()
				.flatMap(list -> list.stream())
				.collect(Collectors.toList());

		subListas.stream()
				.filter(n -> {
					if (n <= 1) return false;

					for (int i = 2; i <= Math.sqrt(n); i++) {
						if (n % i == 0) {
							return false;
						}
					}
					return true;
				})
				.collect(Collectors.toList())
				.forEach(System.out::println);

		List<Pessoa> pessoas = Arrays.asList(
				new Pessoa("Alice", 22),
				new Pessoa("Bob", 17),
				new Pessoa("Charlie", 19)
		);

		pessoas.stream()
				.filter(p -> p.idade >= 18)
				.sorted(Comparator.comparing(Pessoa::getNome))
				.forEach(System.out::println);

		List<Produto> produtos = Arrays.asList(
				new Produto("Smartphone", 800.0, "Eletrônicos"),
				new Produto("Notebook", 1500.0, "Eletrônicos"),
				new Produto("Teclado", 200.0, "Eletrônicos"),
				new Produto("Cadeira", 300.0, "Móveis"),
				new Produto("Monitor", 900.0, "Eletrônicos"),
				new Produto("Mesa", 700.0, "Móveis")
		);

		produtos.stream()
				.filter(p -> p.getCategoria().equals("Eletrônicos"))
				.filter(p -> p.getPreco() < 1000.0)
				.sorted(Comparator.comparingDouble(Produto::getPreco))
				.forEach(System.out::println);

		produtos.stream()
				.filter(p -> p.getCategoria().equals("Eletrônicos"))
				.sorted(Comparator.comparingDouble(Produto::getPreco))
				.limit(3)
				.forEach(System.out::println);
	}

	private static void lambdas() {
		OperacaoMatematica operacao = (num1, num2) -> num1 * num2;

		NumeroPrimo primo = (n) -> {
			if (n <= 1) return false;

			for (int i = 2; i <= Math.sqrt(n); i++) {
				if (n % i == 0) {
					return false;
				}
			}
			return true;
		};

		UpperChars upper = String::toUpperCase;

		Palindromo palim = (str) -> {
			StringBuilder sb = new StringBuilder(str);
			if (sb.reverse().toString().equals(str)) {
				return true;
			}

			return false;
		};

		List<Integer> numeros = Arrays.asList(1, 2, 3, 4, 5);
		numeros.replaceAll(n -> n * 3);
		System.out.println(numeros);

		List<String> nomes = Arrays.asList("Lucas", "Maria", "João", "Ana");
		nomes.sort((a, b) -> a.compareTo(b));
		System.out.println(nomes);

		Divisor divisor = (a, b) -> {
			if (b == 0) throw new ArithmeticException("Divisão por zero");
			return a / b;
		};

		try {
			System.out.println(divisor.dividir(10, 2)); // Esperado: 5
			System.out.println(divisor.dividir(10, 0)); // Esperado: Exceção
		} catch (ArithmeticException e) {
			System.out.println(e.getMessage());
		}

		System.out.println(operacao.executar(2, 2));
		System.out.println(primo.isPrimo(11));
		System.out.println(upper.toUpper("mario"));
		System.out.println(palim.isPalindromo("ana"));
	}

	private static void jsonArquivo() throws IOException {
		Tarefa tarefa = new Tarefa(
				"Aula de Spring",
				true,
				"Jennifer"
		);

		ObjectMapper mapper = new ObjectMapper();
		String serializado = mapper.writeValueAsString(tarefa);
		File serializadoArquivo = new File("tarefa.json");
		FileOutputStream fos = new FileOutputStream(serializadoArquivo);
		fos.write(serializado.getBytes());
		fos.close();

		FileInputStream fis = new FileInputStream(serializadoArquivo);
		byte[] bytes = fis.readAllBytes();
		Tarefa tarefa1 = mapper.readValue(bytes, Tarefa.class);
		System.out.println(tarefa1);
	}

	private static void lerDigito() {
		Scanner sc = new Scanner(System.in);
		System.out.println("Digite um numero: ");
		int numero = sc.nextInt();
		for (int i = 1; i <= numero; i++) {
			System.out.print(i + " 5");
		}
	}
}
