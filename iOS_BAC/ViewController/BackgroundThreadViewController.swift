//
//  BackgroundThreadViewController.swift
//  iOS_BAC
//
//  Created by Nathalie Slowak on 09.05.18.
//  Copyright © 2018 Sebastian Slowak. All rights reserved.
//

import UIKit

class BackgroundThreadViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }

    @IBOutlet weak var ResultLabel: UILabel!
    @IBAction func StartBackgroundThreadButton(_ sender: UIButton) {
        let start = DispatchTime.now()
        let primeService = PrimeService()
        primeService.FindPrimeNumber(x: 100000) { result in
            DispatchQueue.main.async {
                 self.ResultLabel.text = result
                let end = DispatchTime.now()
                let nanotime = end.uptimeNanoseconds - start.uptimeNanoseconds
                let timeinterval = Double(nanotime) / 1000000
                NSLog("BackgroundThread: "+String(timeinterval))
            }
        }
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
