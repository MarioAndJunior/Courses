package br.com.alura;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashSet;

public class TestaPerformance {

    public static void main(String[] args) {

        Collection<Integer> numeros = new HashSet<Integer>();
        Collection<Integer> listaNumeros = new ArrayList<Integer>();

        long inicio = System.currentTimeMillis();

        for (int i = 1; i <= 100000; i++) {
            numeros.add(i);
        }

        for (Integer numero : numeros) {
            numeros.contains(numero);
        }

        long fim = System.currentTimeMillis();

        long tempoDeExecucao = fim - inicio;

        System.out.println("Tempo gasto com HashSet: " + tempoDeExecucao + " ms");
        
        inicio = System.currentTimeMillis();

        for (int i = 1; i <= 100000; i++) {
        	listaNumeros.add(i);
        }

        for (Integer numero : listaNumeros) {
        	listaNumeros.contains(numero);
        }

        fim = System.currentTimeMillis();

        tempoDeExecucao = fim - inicio;

        System.out.println("Tempo gasto com ArrayList: " + tempoDeExecucao + " ms");

    }

}