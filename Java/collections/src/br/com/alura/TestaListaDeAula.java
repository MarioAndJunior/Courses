package br.com.alura;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

public class TestaListaDeAula {
	public static void main(String[] args) {
		Aula a1 = new Aula("Revisitando as ArrayLists", 21);
		Aula a2 = new Aula("Listas de objetos", 20);
		Aula a3 = new Aula("Relacionamento de listas e objetos", 15);
		
		String s1 = "Mario";
		String s2 = "Junior";
		System.out.println(s1.compareTo(s2));

		ArrayList<Aula> aulas = new ArrayList<Aula>();
		
		aulas.add(a1);
		aulas.add(a2);
		aulas.add(a3);
		
		System.out.println(aulas);
		Collections.sort(aulas);
		System.out.println(aulas);
		
		Collections.sort(aulas, Comparator.comparing(Aula::getTempo));
		System.out.println(aulas);
		
		aulas.sort(Comparator.comparing(Aula::getTempo));
		System.out.println(aulas);
		
	}
}
