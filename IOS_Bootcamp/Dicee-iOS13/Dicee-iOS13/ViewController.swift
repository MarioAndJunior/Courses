//
//  ViewController.swift
//  Dicee-iOS13
//
//  Created by Angela Yu on 11/06/2019.
//  Copyright © 2019 London App Brewery. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    // IBOutlet referencia componentes UI -> control e drag
    @IBOutlet weak var diceImageView1: UIImageView!
    @IBOutlet weak var diceImageView2: UIImageView!
    
    // let é imutável, let vem de deixar em inglês. "Deixe dices com os valores"
    let dices = [
        UIImage(imageLiteralResourceName: "DiceOne"),
        UIImage(imageLiteralResourceName: "DiceTwo"),
        UIImage(imageLiteralResourceName: "DiceThree"),
        UIImage(imageLiteralResourceName: "DiceFour"),
        UIImage(imageLiteralResourceName: "DiceFive"),
        UIImage(imageLiteralResourceName: "DiceSix")
    ]

    @IBAction func rollButtonPressed(_ sender: UIButton) {
        
        // https://www.khanacademy.org/computing/computer-science/cryptography/crypt/v/random-vs-pseudorandom-number-generators
        diceImageView1.image = dices.randomElement() // ou [Int.random(in: 0...5)]
        diceImageView2.image = dices.randomElement() // ou [Int.random(in: 0...5)]
    }
    
}

