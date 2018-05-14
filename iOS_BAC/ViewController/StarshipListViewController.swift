//
//  StarshipListViewController.swift
//  iOS_BAC
///Users/nathalieslowak/Desktop/iOS_BAC/iOS_BAC/StarshipService.swift
//  Created by Nathalie Slowak on 10.05.18.
//  Copyright © 2018 Sebastian Slowak. All rights reserved.
//

import UIKit

class StarshipListViewController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    
    var allstarships = [StarshipModel]()
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return allstarships.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = StarshipTable.dequeueReusableCell(withIdentifier: "starshipCell") as!  StarshipTableViewCell
        
        cell.NameLabel.text = allstarships[indexPath.row].name
        cell.LengthLabel.text = String(allstarships[indexPath.row].length)
        return cell
    }
    

    
    override func viewDidLoad() {
        StarshipTable.delegate = self
        StarshipTable.dataSource = self
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }

    @IBOutlet weak var StarshipTable: UITableView!
    @IBAction func getStarships(_ sender: Any) {
        let start = DispatchTime.now()
        let starshipService: StarshipService = StarshipService()
        starshipService.GetStarships() {[weak self] starships in
            if starships != nil, self != nil {
                self!.allstarships.append(contentsOf: starships!)
                print(self!.allstarships.count)

                DispatchQueue.main.async {
                    self!.StarshipTable.reloadData()
                }
            }
        }
        let end = DispatchTime.now()
        let nanotime = end.uptimeNanoseconds - start.uptimeNanoseconds
        let timeinterval = Double(nanotime) / 1000000
        NSLog("StarshipList: "+String(timeinterval))
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
