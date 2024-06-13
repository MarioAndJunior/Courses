//
//  StoryBrain.swift
//  Destini-iOS13
//
//  Created by Angela Yu on 08/08/2019.
//  Copyright © 2019 The App Brewery. All rights reserved.
//

import Foundation

struct StoryBrain {
    let stories = [
        Story(title: "You see a fork in the road", choice1: "Take a left", choice2: "Take a right"),
        Story(title: "You see a tiger", choice1: "Shout for help", choice2: "Play dead"),
        Story(title: "You see a treasure chest", choice1: "Open it", choice2: "Check for traps")
    ]

    var currentStoryIndex = 0
    
    mutating func nextStory(choiceMade: String) -> Story {
        if (choiceMade == "initial") {
            return stories[0]
        }
        
        if (currentStoryIndex == 0) {
            let leftChoose = choiceMade.elementsEqual(stories[0].choice1)
            
            if (leftChoose == true) {
                currentStoryIndex = 1
            } else {
                currentStoryIndex = 2
            }
        }
        
        return stories[currentStoryIndex]
    }
}
