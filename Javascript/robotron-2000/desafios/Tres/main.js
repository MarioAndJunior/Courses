var lista = ["Laranja", "Vermelho", "Branco", "Amarelo", "Rosa"]; 

console.log("antes");
lista.forEach( (item) => {
    console.log(item)
});

lista.splice(1, 1);

console.log("depois");
lista.forEach( (item) => {
    console.log(item)
});