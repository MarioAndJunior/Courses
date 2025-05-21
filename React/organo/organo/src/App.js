import { useState } from 'react';
import Banner from './componentes/Banner';
import Formulario from './componentes/Formulario';
import Time from './componentes/Time';
import Rodape from './componentes/Rodape';

function App() {

  const [times, setTimes] = useState([
    {
      nome: 'Programação',
      cor: '#57C278',
    },
    {
      nome: 'Front-end',
      cor: '#82CFFA',
    },
    {
      nome: 'Data Science',
      cor: '#A6D157',    },
    {
      nome: 'Devops',
      cor: '#E06B69',
    },
    {
      nome: 'Ux e Design',
      cor: '#DB6EBF',
    },
    {
      nome: 'Mobile',
      cor: '#FFBA05',
    },
    {
      nome: 'Inovação e Gestão',
      cor: '#FF8A29',
    },
])

const inicial = [
  {
    nome: 'JULIANA AMOASEI',
    cargo: 'Desenvolvedora de software e instrutora',
    imagem: 'https://www.alura.com.br/assets/img/lideres/juliana-amoasei.1647533644.jpeg',
    time: times[0].nome
  },
  {
    nome: 'DANIEL ARTINE',
    cargo: 'Engenheiro de Software na Stone Age',
    imagem: 'https://www.alura.com.br/assets/img/lideres/daniel-artine.1647533644.jpeg',
    time: times[0].nome
  },
  {
    nome: 'GUILHERME LIMA',
    cargo: 'Desenvolvedor Python e JavaScript na Alura',
    imagem: '	https://www.alura.com.br/assets/img/lideres/guilherme-lima.1647533644.jpeg',
    time: times[0].nome
  },
  {
    nome: 'PAULO SILVEIRA',
    cargo: 'Hipster e CEO da Alura',
    imagem: 'https://www.alura.com.br/assets/img/lideres/paulo-silveira.1647533644.jpeg',
    time: times[0].nome
  },
  {
    nome: 'JULIANA AMOASEI',
    cargo: 'Desenvolvedora de software e instrutora',
    imagem: 'https://www.alura.com.br/assets/img/lideres/juliana-amoasei.1647533644.jpeg',
    time: times[1].nome
  },
  {
    nome: 'DANIEL ARTINE',
    cargo: 'Engenheiro de Software na Stone Age',
    imagem: 'https://www.alura.com.br/assets/img/lideres/daniel-artine.1647533644.jpeg',
    time: times[1].nome
  },
  {
    nome: 'GUILHERME LIMA',
    cargo: 'Desenvolvedor Python e JavaScript na Alura',
    imagem: '	https://www.alura.com.br/assets/img/lideres/guilherme-lima.1647533644.jpeg',
    time: times[1].nome
  },
  {
    nome: 'PAULO SILVEIRA',
    cargo: 'Hipster e CEO da Alura',
    imagem: 'https://www.alura.com.br/assets/img/lideres/paulo-silveira.1647533644.jpeg',
    time: times[1].nome
  },
  {
    nome: 'JULIANA AMOASEI',
    cargo: 'Desenvolvedora de software e instrutora',
    imagem: 'https://www.alura.com.br/assets/img/lideres/juliana-amoasei.1647533644.jpeg',
    time: times[2].nome
  },
  {
    nome: 'DANIEL ARTINE',
    cargo: 'Engenheiro de Software na Stone Age',
    imagem: 'https://www.alura.com.br/assets/img/lideres/daniel-artine.1647533644.jpeg',
    time: times[2].nome
  },
  {
    nome: 'GUILHERME LIMA',
    cargo: 'Desenvolvedor Python e JavaScript na Alura',
    imagem: '	https://www.alura.com.br/assets/img/lideres/guilherme-lima.1647533644.jpeg',
    time: times[2].nome
  },
  {
    nome: 'PAULO SILVEIRA',
    cargo: 'Hipster e CEO da Alura',
    imagem: 'https://www.alura.com.br/assets/img/lideres/paulo-silveira.1647533644.jpeg',
    time: times[2].nome
  },
  {
    nome: 'JULIANA AMOASEI',
    cargo: 'Desenvolvedora de software e instrutora',
    imagem: 'https://www.alura.com.br/assets/img/lideres/juliana-amoasei.1647533644.jpeg',
    time: times[3].nome
  },
  {
    nome: 'DANIEL ARTINE',
    cargo: 'Engenheiro de Software na Stone Age',
    imagem: 'https://www.alura.com.br/assets/img/lideres/daniel-artine.1647533644.jpeg',
    time: times[3].nome
  },
  {
    nome: 'GUILHERME LIMA',
    cargo: 'Desenvolvedor Python e JavaScript na Alura',
    imagem: '	https://www.alura.com.br/assets/img/lideres/guilherme-lima.1647533644.jpeg',
    time: times[3].nome
  },
  {
    nome: 'PAULO SILVEIRA',
    cargo: 'Hipster e CEO da Alura',
    imagem: 'https://www.alura.com.br/assets/img/lideres/paulo-silveira.1647533644.jpeg',
    time: times[3].nome
  },
  {
    nome: 'JULIANA AMOASEI',
    cargo: 'Desenvolvedora de software e instrutora',
    imagem: 'https://www.alura.com.br/assets/img/lideres/juliana-amoasei.1647533644.jpeg',
    time: times[4].nome
  },
  {
    nome: 'DANIEL ARTINE',
    cargo: 'Engenheiro de Software na Stone Age',
    imagem: 'https://www.alura.com.br/assets/img/lideres/daniel-artine.1647533644.jpeg',
    time: times[4].nome
  },
  {
    nome: 'GUILHERME LIMA',
    cargo: 'Desenvolvedor Python e JavaScript na Alura',
    imagem: '	https://www.alura.com.br/assets/img/lideres/guilherme-lima.1647533644.jpeg',
    time: times[4].nome
  },
  {
    nome: 'PAULO SILVEIRA',
    cargo: 'Hipster e CEO da Alura',
    imagem: 'https://www.alura.com.br/assets/img/lideres/paulo-silveira.1647533644.jpeg',
    time: times[4].nome
  },
  {
    nome: 'JULIANA AMOASEI',
    cargo: 'Desenvolvedora de software e instrutora',
    imagem: 'https://www.alura.com.br/assets/img/lideres/juliana-amoasei.1647533644.jpeg',
    time: times[5].nome
  },
  {
    nome: 'DANIEL ARTINE',
    cargo: 'Engenheiro de Software na Stone Age',
    imagem: 'https://www.alura.com.br/assets/img/lideres/daniel-artine.1647533644.jpeg',
    time: times[5].nome
  },
  {
    nome: 'GUILHERME LIMA',
    cargo: 'Desenvolvedor Python e JavaScript na Alura',
    imagem: '	https://www.alura.com.br/assets/img/lideres/guilherme-lima.1647533644.jpeg',
    time: times[5].nome
  },
  {
    nome: 'PAULO SILVEIRA',
    cargo: 'Hipster e CEO da Alura',
    imagem: 'https://www.alura.com.br/assets/img/lideres/paulo-silveira.1647533644.jpeg',
    time: times[5].nome
  },
]
  const [colaboradores, setColaboradores] = useState(inicial)

  const aoNovoColaboradorAdicionado = (colaborador) => {
    console.log(colaborador)
    setColaboradores([...colaboradores, colaborador])
  }

  function deletarColaborador() {
    console.log("deletando colaborador")
  }

  function mudarCorDoTime(cor, nome) {
    setTimes(times.map(time => {
      if (time.nome === nome) {
        time.cor = cor
      }
      return time;
    }));
  }

  return (
    <div className="App">
      <Banner />
      <Formulario times={times.map(time => time.nome)} aoColaboradorCadastrado={colaborador => aoNovoColaboradorAdicionado(colaborador)} />
      {times.map(time => <Time 
        key={time.nome} 
        nome={time.nome} 
        cor={time.cor} 
        corSecundaria={time.corSecundaria}
        colaboradores={colaboradores.filter(colaborador => colaborador.time === time.nome)}
        aoDeletar ={deletarColaborador}
        mudarCor = {mudarCorDoTime}
        />)}
      <Rodape />
    </div>
  );
}

export default App;
