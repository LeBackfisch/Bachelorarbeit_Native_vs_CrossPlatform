//
//  ViewController.swift
//  iOS_BAC
//
//  Created by Nathalie Slowak on 09.05.18.
//  Copyright © 2018 Sebastian Slowak. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        NSLog("Startup: "+String(measureStartUpTime()))
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func measureStartUpTime() -> Double {
        var kinfo = kinfo_proc()
        var size = MemoryLayout<kinfo_proc>.stride
        var mib : [Int32] = [CTL_KERN, KERN_PROC, KERN_PROC_PID, getpid()]
        sysctl(&mib, u_int(mib.count), &kinfo, &size, nil, 0)
        let start_time = kinfo.kp_proc.p_starttime
        var time: timeval = timeval(tv_sec: 0, tv_usec: 0)
        gettimeofday(&time, nil)
        let currentTimeMilliseconds = Double(Int64(time.tv_sec) * 1000) + Double(time.tv_sec) / 1000.0
        let processTimeMilliseconds = Double(Int64(start_time.tv_sec) * 1000) + Double(start_time.tv_usec) / 1000.0
        return ((currentTimeMilliseconds - processTimeMilliseconds) / 1000.0)
    }


}

