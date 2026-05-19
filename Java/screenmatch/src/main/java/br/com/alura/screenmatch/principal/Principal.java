package br.com.alura.screenmatch.principal;

import br.com.alura.screenmatch.model.DadosEpisodio;
import br.com.alura.screenmatch.model.DadosSerie;
import br.com.alura.screenmatch.model.DadosTemporada;
import br.com.alura.screenmatch.model.Episodio;
import br.com.alura.screenmatch.service.ConsumoAPI;
import br.com.alura.screenmatch.service.ConverteDados;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.stream.Collectors;

public class Principal {
    private static final String ENDERECO = "https://www.omdbapi.com/?t=";
    private static final String API_KEY = "&apikey=6585022c";
    private final Scanner leitura = new Scanner(System.in);
    private final ConsumoAPI consumoAPI = new ConsumoAPI();
    private final ConverteDados conversor = new ConverteDados();

    public void exibeMenu() {
        System.out.println("Digite o nome da série");
        var nomeSerie = leitura.nextLine();
        String endereco = ENDERECO + nomeSerie.replace(' ', '+') + API_KEY;

        var json =  consumoAPI.obterDados(endereco);
        DadosSerie dados = conversor.obterDados(json, DadosSerie.class);
        System.out.println(dados);
        System.out.println();

        List<DadosTemporada> temporadas = new ArrayList<>();
		for (int i = 1; i <= dados.totalTemporadas(); i++) {
			json =  consumoAPI.obterDados(ENDERECO + nomeSerie.replace(' ', '+') + "&season=" + i + API_KEY);
			DadosTemporada temporada = conversor.obterDados(json, DadosTemporada.class);
			temporadas.add(temporada);
		}

//		temporadas.forEach(System.out::println);
//        for (int i = 0; i < dados.totalTemporadas(); i++) {
//            List <DadosEpisodio> episodiosTemporada = temporadas.get(i).episodios();
//            for (int j = 0; j < episodiosTemporada.size(); j++) {
//                System.out.println(episodiosTemporada.get(j).titulo());
//            }
//        }

//        temporadas.forEach(t -> t.episodios().forEach(e -> System.out.println(e.titulo())));

        List<DadosEpisodio> dadosEpisodios = temporadas.stream()
                .flatMap(t -> t.episodios().stream())
                .collect(Collectors.toList()); //toList() devolve um imutável

//        System.out.println("\nTop 5 episodios:");
//        dadosEpisodios.stream()
//                .filter(e -> !e.avaliacao().equals("N/A"))
//                .sorted(Comparator.comparing(DadosEpisodio::avaliacao).reversed())
//                .limit(5)
//                .forEach(System.out::println);

//        System.out.println("\nTop 10 episodios:");
//        dadosEpisodios.stream()
//                .filter(e -> !e.avaliacao().equals("N/A"))
//                .peek(e -> System.out.println("Primeiro filtro(N/A) " + e))
//                .sorted(Comparator.comparing(DadosEpisodio::avaliacao).reversed())
//                .peek(e -> System.out.println("Ordenacao " + e))
//                .limit(10)
//                .peek(e -> System.out.println("limit " + e))
//                .map(e -> e.titulo().toUpperCase())
//                .peek(e -> System.out.println("upper " + e))
//                .forEach(System.out::println);

        List<Episodio> episodios =  temporadas.stream()
                .flatMap(t -> t.episodios().stream()
                        .map(d -> new Episodio(t.numero(), d))
                )
                .collect(Collectors.toList());

        episodios.forEach(System.out::println);

//        System.out.println("Digite um trecho do que busca");
//        var trechoTitulo = leitura.nextLine();
//        Optional<Episodio> episodioBuscado = episodios.stream()
//                .filter(e -> e.getTitulo().toUpperCase().contains(trechoTitulo.toUpperCase()))
//                .findFirst();
//
//        if (episodioBuscado.isPresent()) {
//            System.out.println("Episodio encontrado");
//            System.out.println("Temporada: " + episodioBuscado.get().getTemporada());
//        } else {
//            System.out.println("Episodio nao encontrado");
//        }
//
//        System.out.println("A partir de qual ano você deseja ver os episódios?");
//        var ano = leitura.nextInt();
//        leitura.nextLine();
//
//        LocalDate dataBusca = LocalDate.of(ano, 1, 1);
//        DateTimeFormatter formatador = DateTimeFormatter.ofPattern("dd/MM/yyyy");
//        episodios.stream()
//                .filter(e -> e.getDataLancamento() != null &&
//                        e.getDataLancamento().isAfter(dataBusca))
//                .forEach(e -> System.out.println(
//                        "Temporada: " + e.getTemporada() +
//                                " Episódio: " + e.getTitulo() +
//                                " Data lancamento: " + formatador.format(e.getDataLancamento())
//                ));

        Map<Integer, Double> avaliacoesPorTemporada = episodios.stream()
                .filter(e -> e.getAvaliacao() > 0.0)
                .collect(Collectors.groupingBy(Episodio::getTemporada,
                        Collectors.averagingDouble(Episodio::getAvaliacao)));

        System.out.println(avaliacoesPorTemporada);

        DoubleSummaryStatistics est = episodios.stream()
                .filter(e -> e.getAvaliacao() > 0.0)
                .collect(Collectors.summarizingDouble(Episodio::getAvaliacao));

        System.out.println("Quantidade de episódios: " + est.getCount());
        System.out.println("Média: " + est.getAverage());
        System.out.println("Melhor episódio: " + est.getMax());
        System.out.println("Pior episódio: " + est.getMin());
    }

}
