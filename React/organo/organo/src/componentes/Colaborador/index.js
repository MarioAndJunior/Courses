import { IoIosCloseCircle } from "react-icons/io";
import { FaHeart, FaRegHeart  } from "react-icons/fa";

import './Colaborador.css'

const Colaborador = ({id, nome, imagem, cargo, corDeFundo, favorito, aoDeletar, aoFavoritar}) => {
    function favoritar() {
        aoFavoritar(id);
    }

    const propsFavorito = {
        size: 25,
        onClick: favoritar
    }
    return (
        <div className='colaborador'>
            <IoIosCloseCircle 
                size={30} 
                className='deletar'
                onClick={() => aoDeletar(id)}
             />
            <div className='cabecalho' style={{backgroundColor: corDeFundo}}>
                <img src={imagem} alt={nome}/>
            </div>
            <div className='rodape'>
                <h4>{nome}</h4>
                <h5>{cargo}</h5>
                <div className='favoritar'>
                    {favorito 
                    ? <FaHeart {...propsFavorito} color='#FF0000'/> 
                    : <FaRegHeart {...propsFavorito} />}
                </div>
            </div>
        </div>
    )
}

export default Colaborador