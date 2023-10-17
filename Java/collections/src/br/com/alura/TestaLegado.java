package br.com.alura;

import java.util.HashSet;
import java.util.Iterator;
import java.util.Set;

public class TestaLegado {
	public static void main(String[] args) {
		Set<String> conjunto = new HashSet<>();
		conjunto.add("A");
		conjunto.add("A"); // não adiciona, já existe
		conjunto.add("B");

		conjunto.forEach(letra -> {
		    System.out.println(letra);
		});
		
		System.out.println();
		for(String letra: conjunto) {
		    System.out.println(letra);
		}
		
		System.out.println();
		Set<String> conjunto2 = conjunto;
		Iterator<String> iterador = conjunto2.iterator();

		while (iterador.hasNext()) {
		    System.out.println(iterador.next());
		}
	}
}
