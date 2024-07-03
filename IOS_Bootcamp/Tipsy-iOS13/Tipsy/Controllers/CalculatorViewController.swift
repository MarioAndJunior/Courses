//
//  ViewController.swift
//  Tipsy
//
//  Created by Angela Yu on 09/09/2019.
//  Copyright © 2019 The App Brewery. All rights reserved.
//

import UIKit

class CalculatorViewController: UIViewController {
    @IBOutlet weak var billTextField: UITextField!
    @IBOutlet weak var zeroPctButton: UIButton!
    @IBOutlet weak var tenPctButton: UIButton!
    @IBOutlet weak var twentyPctButton: UIButton!
    @IBOutlet weak var splitNumberLabel: UILabel!
    
    var tipPercentage = 0.0
    var billPerPerson = ""
    var personsNumber = 2.0
    
    @IBAction func tipChanged(_ sender: UIButton) {
        billTextField.endEditing(true)
        if (sender == zeroPctButton) {
            zeroPctButton.isSelected = true
            tenPctButton.isSelected = false
            twentyPctButton.isSelected = false
            tipPercentage = 0.0
        } else if (sender == tenPctButton) {
            zeroPctButton.isSelected = false
            tenPctButton.isSelected = true
            twentyPctButton.isSelected = false
            tipPercentage = 0.1
        } else if (sender == twentyPctButton) {
            zeroPctButton.isSelected = false
            tenPctButton.isSelected = false
            twentyPctButton.isSelected = true
            tipPercentage = 0.2
        }
    }
    
    @IBAction func stepperValueChanged(_ sender: UIStepper) {
        splitNumberLabel.text = String(format: "%.0f", sender.value)
        personsNumber = sender.value
    }
    
    @IBAction func calculatePressed(_ sender: UIButton) {
        let billValue = billTextField.text ?? ""
        let billValueDouble = Double(billValue) ?? 0.0
        let billPerPersonNumeric = (billValueDouble + (billValueDouble * tipPercentage)) / personsNumber
        billPerPerson = String(format: "%.2f", billPerPersonNumeric)
        
        print(billPerPerson)
        
        self.performSegue(withIdentifier: "goToResults", sender: self)
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if (segue.identifier == "goToResults") {
            let destinationVC = segue.destination as! ResultsViewController
            destinationVC.result = billPerPerson
            destinationVC.splitNumber = Int(personsNumber)
            destinationVC.tip = Int(tipPercentage * 100)
        }
    }
    
}

