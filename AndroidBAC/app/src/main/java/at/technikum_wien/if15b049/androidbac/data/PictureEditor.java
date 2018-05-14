package at.technikum_wien.if15b049.androidbac.data;

import android.graphics.Bitmap;
import android.graphics.ColorMatrix;
import android.graphics.ColorMatrixColorFilter;

/**
 * Created by Sebastian on 28.04.2018.
 */

public class PictureEditor {

    public PictureEditor(){

    }

    public ColorMatrixColorFilter grayScaleBitMap(Bitmap bitmap){
        ColorMatrix matrix = new ColorMatrix();
        matrix.setSaturation(0);
        ColorMatrixColorFilter filter = new ColorMatrixColorFilter(matrix);
        return filter;
    }


}
