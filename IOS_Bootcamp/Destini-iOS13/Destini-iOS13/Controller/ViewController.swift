//
//  ViewController.swift
//  Destini-iOS13
//
//  Created by Angela Yu on 08/08/2019.
//  Copyright © 2019 The App Brewery. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    @IBOutlet weak var storyLabel: UILabel!
    @IBOutlet weak var choice1Button: UIButton!
    @IBOutlet weak var choice2Button: UIButton!
    var brain = StoryBrain()
    var currentStory: Story = Story(title: "", choice1: "", choice2: "")
    
    @IBAction func choiceMade(_ sender: UIButton) {
        let choiceMade = sender.currentTitle!
        currentStory = brain.nextStory(choiceMade: choiceMade)
        updateUI()
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        currentStory = brain.nextStory(choiceMade: "initial")
        updateUI()
    }
    
    func updateUI() {
        storyLabel.text = currentStory.title
        choice1Button.setTitle(currentStory.choice1, for: .normal)
        choice2Button.setTitle(currentStory.choice2, for: .normal)
    }


}

