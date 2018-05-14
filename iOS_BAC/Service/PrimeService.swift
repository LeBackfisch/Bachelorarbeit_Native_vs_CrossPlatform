//
//  PrimeService.swift
//  iOS_BAC
//
//  Created by Nathalie Slowak on 09.05.18.
//  Copyright © 2018 Sebastian Slowak. All rights reserved.
//

import Foundation

public class PrimeService {
    
    func FindPrimeNumber(x: Int, completion: @escaping (_ result: String) -> Void) {
        var a: Int32 = 2
        DispatchQueue.global(qos: .default).async {
            var count: Int = 0
            
            while count < x {
                var b : Int32 = 2
                var prime: Int = 1
                while b * b <= a {
                    if a % b == 0 {
                        prime = 0
                        break
                    }
                    b += 1
                }
                if prime > 0 {
                    count += 1
                }
                a += 1
                
            }
            a -= 1
            completion(String(a))
        }
    }
}
