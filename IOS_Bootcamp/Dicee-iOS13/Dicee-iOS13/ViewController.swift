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
    
    var dices = [
        UIImage(imageLiteralResourceName: "DiceOne"),
        UIImage(imageLiteralResourceName: "DiceTwo"),
        UIImage(imageLiteralResourceName: "DiceThree"),
        UIImage(imageLiteralResourceName: "DiceFour"),
        UIImage(imageLiteralResourceName: "DiceFive"),
        UIImage(imageLiteralResourceName: "DiceSix")
    ]
    
    var leftDiceNumber = 1
    var rightDiceNumber = 5
    
    override func viewDidLoad() {
        super.viewDidLoad()
    }

    @IBAction func rollButtonPressed(_ sender: UIButton) {
        diceImageView1.image = dices[leftDiceNumber]
        diceImageView2.image = dices[rightDiceNumber]
        if (leftDiceNumber == 5) {
            leftDiceNumber = -1
        }
        if (rightDiceNumber == 0) {
            rightDiceNumber = 6
        }
        leftDiceNumber = leftDiceNumber + 1
        rightDiceNumber = rightDiceNumber - 1
    }
    
}

