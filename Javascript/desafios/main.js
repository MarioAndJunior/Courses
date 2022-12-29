const listaDeTeclas = document.querySelectorAll('input[type=button]');

console.log(listaDeTeclas);

function imprimeTelefone () {
    console.log(document.querySelector('input[type=tel]').value);
  }
  
  for(let contador = 0; contador < listaDeTeclas.length; contador++) {
    const tecla = listaDeTeclas[contador];
    tecla.onclick = function () {
      imprimeTelefone();
    }

    tecla.onkeydown = function () {
      tecla.classList.add('ativa');
    }
    
    tecla.onkeyup = function() {
      tecla.classList.remove('ativa');
    }
  }