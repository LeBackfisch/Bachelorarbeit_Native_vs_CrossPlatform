//
//  StarshipModel.swift
//  iOS_BAC
//
//  Created by Nathalie Slowak on 10.05.18.
//  Copyright © 2018 Sebastian Slowak. All rights reserved.
//

import Foundation

class StarshipModel {
    var name: String
    var model: String
    var manufacturer: String
    var length: Float32
    
    init(_ name: String, model: String, manufacturer: String, length: Float32) {
        self.name = name
        self.model = model
        self.length = length
        self.manufacturer = manufacturer
    }
}
