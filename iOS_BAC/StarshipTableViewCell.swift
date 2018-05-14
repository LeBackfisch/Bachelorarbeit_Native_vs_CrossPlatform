//
//  StarshipTableViewCell.swift
//  iOS_BAC
//
//  Created by Nathalie Slowak on 10.05.18.
//  Copyright © 2018 Sebastian Slowak. All rights reserved.
//

import UIKit

class StarshipTableViewCell: UITableViewCell {

    @IBOutlet weak var NameLabel: UILabel!
    @IBOutlet weak var LengthLabel: UILabel!
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }

}
