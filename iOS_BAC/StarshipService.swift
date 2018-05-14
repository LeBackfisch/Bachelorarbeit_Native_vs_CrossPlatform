//
//  StarshipService.swift
//  iOS_BAC
//
//  Created by Nathalie Slowak on 09.05.18.
//  Copyright © 2018 Sebastian Slowak. All rights reserved.
//

import Foundation

public class StarshipService {
    var starships = [StarshipModel]()
    
    func GetStarships(returnCompletion: @escaping ([StarshipModel]?) -> Void) {
        let jsonUrlString = "https://swapi.co/api/starships"
        
        guard let url = URL(string: jsonUrlString) else { return }
        let session = URLSession.shared
        session.dataTask(with: url) { (data, response, error) in
            if let e = error {
                print(e.localizedDescription)
                return
            }
            
            DispatchQueue.global(qos: .default).async {
                guard let jsonString = data else {
                    print("Cannot get JSON string")
                    return
                }
                guard let json = try? JSONSerialization.jsonObject(with: jsonString, options: []) else {
                    print("Cannot parse JSON data")
                    return
                }
                guard let rootJson = json as? [String: Any] else {
                    print("root element not found")
                    return
                }
                guard let results = rootJson["results"] as? [[String: Any]] else {
                    print("no results found")
                    return
                }
                var starships = [StarshipModel]()
                for result in results {
                    guard let newStarship = StarshipModel(json: result) else {
                        print("Could not serialize Starship")
                        return
                    }
                    starships.append(newStarship)
                }
                 returnCompletion(starships)
            }
        }.resume()
    }
}

extension StarshipModel {
    convenience init?(json:[String: Any]){
        guard let name = json["name"] as? String else {
            return nil
        }
        guard let model = json["model"] as? String else {
            return nil
        }
        guard let manufacturer = json["manufacturer"] as? String else {
            return nil
        }
        guard let length = json["length"] as? String else {
            return nil
        }
        
        self.init(name, model: model, manufacturer: manufacturer, length: Float32(length)!)
        
    }
}
