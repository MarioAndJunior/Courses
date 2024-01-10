print("Excercise 1")

var a = 5
var b = 8

var temp = b
b = a
a = temp

print("a: \(a)")
print("b: \(b)")

print("Excercise 2")

let numbers = [45, 73, 195, 53]
let computedNumbers = [numbers[0] * numbers[1], numbers[1] * numbers[2], numbers[2] * numbers[3], numbers[3] * numbers[0]]

print(computedNumbers)

print("Excercise 3")

let alphabet = ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"]

//The number of letters in alphabet equals 26

var password = alphabet[Int.random(in:0...25)] + alphabet[Int.random(in:0...25)] + alphabet[Int.random(in:0...25)] + alphabet[Int.random(in:0...25)] + alphabet[Int.random(in:0...25)] + alphabet[Int.random(in:0...25)]

print(password)
