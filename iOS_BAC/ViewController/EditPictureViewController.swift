//
//  EditPictureViewController.swift
//  iOS_BAC
//
//  Created by Nathalie Slowak on 10.05.18.
//  Copyright © 2018 Sebastian Slowak. All rights reserved.
//

import UIKit

class EditPictureViewController: UIViewController, UINavigationControllerDelegate, UIImagePickerControllerDelegate {
    @IBOutlet weak var takePictureButton: UIButton!
    @IBOutlet weak var editPictureButtn: UIButton!
    @IBOutlet weak var savePictureButton: UIButton!
    private var isClicked: Bool = false
    private var originalImage: UIImage = UIImage()
    private var startSaveTime: DispatchTime? = nil
    
    var imagePickerController: UIImagePickerController!
    override func viewDidLoad() {
        super.viewDidLoad()
        editPictureButtn.isEnabled = false
        savePictureButton.isEnabled = false
    }

    @IBOutlet weak var pictureImageView: UIImageView!
    @IBAction func TakePictureButton(_ sender: Any) {
        imagePickerController = UIImagePickerController()
        imagePickerController.delegate = self
        imagePickerController.sourceType = .camera
        
        present(imagePickerController, animated: true, completion: nil)
        
    }
    
    @IBAction func EditPictureButton(_ sender: Any) {
        let start = DispatchTime.now()
        if isClicked {
            pictureImageView.image = originalImage
            isClicked = false
        }
        else {
            originalImage = pictureImageView.image!
            _ = CIImage(image: pictureImageView.image!)
            let originalOrientation: UIImageOrientation = pictureImageView.image!.imageOrientation
            let context = CIContext(options: nil)
             let currentFilter = CIFilter(name: "CIPhotoEffectNoir")
            currentFilter!.setValue(CIImage(image: pictureImageView.image!), forKey: kCIInputImageKey)
            let output = currentFilter!.outputImage
            
            let cgimg = context.createCGImage(output!,from: output!.extent)
            let processedImage = UIImage(cgImage: cgimg!, scale: 1.0 ,orientation: originalOrientation)
            pictureImageView.image = processedImage
            isClicked = true
        }
        
        let end = DispatchTime.now()
        let nanotime = end.uptimeNanoseconds - start.uptimeNanoseconds
        let timeinterval = Double(nanotime) / 1000000
        NSLog("Edit Picture: "+String(timeinterval))
    }
    @IBAction func SavePictureButton(_ sender: Any) {
        startSaveTime = DispatchTime.now()
        UIImageWriteToSavedPhotosAlbum(pictureImageView.image!, self, #selector(image(_:didFinishSavingWithError:contextInfo:)), nil)
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    
    func imagePickerController(_ picker: UIImagePickerController, didFinishPickingMediaWithInfo info: [String : Any]) {
        imagePickerController.dismiss(animated: true, completion: nil)
        
        pictureImageView.image = info[UIImagePickerControllerOriginalImage] as? UIImage
        originalImage = (info[UIImagePickerControllerOriginalImage] as? UIImage)!
        editPictureButtn.isEnabled = true
        savePictureButton.isEnabled = true
        isClicked = false
    }
    
    @objc func image(_ image: UIImage, didFinishSavingWithError error: Error?, contextInfo: UnsafeRawPointer) {
        if let error = error {
            let ac = UIAlertController(title: "Save error", message: error.localizedDescription, preferredStyle: .alert)
            ac.addAction(UIAlertAction(title: "OK", style: .default))
            present(ac, animated: true)
        } else {
           /* let ac = UIAlertController(title: "Saved!", message: "Your altered image has been saved to your photos.", preferredStyle: .alert)
            ac.addAction(UIAlertAction(title: "OK", style: .default))
            present(ac, animated: true) */
        }
        let end = DispatchTime.now()
        let nanotime = end.uptimeNanoseconds - startSaveTime!.uptimeNanoseconds
        let timeinterval = Double(nanotime) / 1000000
        NSLog("Save Picture: "+String(timeinterval))
    }
}
