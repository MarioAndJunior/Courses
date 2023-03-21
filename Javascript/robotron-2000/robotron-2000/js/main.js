const robotron = document.querySelector("#robotron");

// funcao nomeada
// robotron.addEventListener("click", dizOi);

// funcao anonima
// robotron.addEventListener("click", function() {
//     console.log('Cliquei no robô');
// });

// funcao anonima com arrow function
robotron.addEventListener("click", (evento) => {
    console.log(evento);
});

function dizOi(nome) {
    if (nome == undefined) {
        nome = 'Usuário';
    }
    console.log('Oi,', nome);
    console.log('Bem-vindo ao Robotron 2000');
}

dizOi();