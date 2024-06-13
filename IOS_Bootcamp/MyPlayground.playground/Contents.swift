//print("Exercise 1")
//
//var a = 5
//var b = 8
//
//var temp = b
//b = a
//a = temp
//
//print("a: \(a)")
//print("b: \(b)")
//
//print("Exercise 2")
//
//let numbers = [45, 73, 195, 53]
//let computedNumbers = [numbers[0] * numbers[1], numbers[1] * numbers[2], numbers[2] * numbers[3], numbers[3] * numbers[0]]
//
//print(computedNumbers)
//
//print("Exercise 3")
//
//let alphabet = ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"]
//

//import CoreText
////The number of letters in alphabet equals 26
//
//var password = alphabet[Int.random(in:0...25)] + alphabet[Int.random(in:0...25)] + alphabet[Int.random(in:0...25)] + alphabet[Int.random(in:0...25)] + alphabet[Int.random(in:0...25)] + alphabet[Int.random(in:0...25)]
//
//print(password)
//
//func greeting() {
//    for _ in 1...4 {
//        print("hello")
//    }
//}
//
//greeting()
//
//func greeting2(whoToGreet: String) {
//    print("Hello, \(whoToGreet)")
//}
//
//greeting2(whoToGreet: "Mario")
//greeting2(whoToGreet: "Angela")


//func loveCalculator() {
//    let loveScore = Int.random(in:0...100)
    
//    if (loveScore > 80) {
//        print("You love each other like Kanye loves Kanye.")
//    } else if (loveScore >= 40) {
//        print("You go together like Coke and Mentos.")
//    } else {
//        print("You will be forever alone.")
//    }
    
//    switch loveScore {
//    case 81...:
//        print("You love each other like Kanye loves Kanye.")
//    case 40... :
//        print("You go together like Coke and Mentos.")
//    default:
//        print("You will be forever alone.")
//    }
//}
//
//loveCalculator()
//let a = 5
//let b = 2
//
//print(Float(a/b))

//struct Town {
//    let name = "MarioLand"
//    var citizens = ["Mario", "Liam"]
//    var resources = ["Grain": 100, "Ore": 42, "Wool": 10]
//
//    func fortify() {
//        print("Defenses increased!")
//    }
//}
//
//var myTown = Town()
//
//print(myTown)
//print(myTown.name)
//print("\(myTown.name) has \(myTown.resources["Grain"]!) bags of grain")
//
//myTown.citizens.append("Luigi")
//print(myTown.citizens)
//
//myTown.fortify()

struct Town {
    let name: String
    var citizens: [String]
    var resources: [String:Int]
    
    init(name: String, citizens: [String], resources: [String:Int]) {
        self.name = name
        self.citizens = citizens
        self.resources = resources
    }
    
    func fortify() {
        print("Defences increased!")
    }
}

var anotherTown = Town(name: "Nameless Island", citizens: ["Tom Hanks"], resources: ["Coconuts": 100])

anotherTown.citizens.append("Wilson")

print(anotherTown.citizens)

var ghostTown = Town(name: "Ghosty McGhostface", citizens: [], resources: ["Tumbleweed": 1])

print(ghostTown.citizens)

ghostTown.fortify()


