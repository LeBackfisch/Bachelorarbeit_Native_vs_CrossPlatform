package at.technikum_wien.if15b049.androidbac.Views;

import android.Manifest;
import android.annotation.TargetApi;
import android.content.ContentResolver;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.ColorMatrix;
import android.graphics.ColorMatrixColorFilter;
import android.graphics.Paint;
import android.graphics.drawable.BitmapDrawable;
import android.icu.text.SimpleDateFormat;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.support.annotation.RequiresApi;
import android.support.v4.content.ContextCompat;
import android.support.v4.content.FileProvider;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.util.Date;

import at.technikum_wien.if15b049.androidbac.R;
import at.technikum_wien.if15b049.androidbac.data.PictureEditor;

import static android.app.Activity.RESULT_OK;

public class EditPictureActivity extends AppCompatActivity {
    static final int REQUEST_IMAGE_CAPTURE = 1;
    private static final int MY_CAMERA_REQUEST_CODE = 100;
    private static final int MY_WRITE_STORAGE_REQUEST_CODE = 101;
    private ImageView mImageView;
    private PictureEditor pictureEditor = new PictureEditor();
    private Button btn;
    private Button savebtn;
    private boolean clicked = false;
    private long startTime =0;
    private long editstartTime =0;
    private String mCurrentPhotoPath = "";
    private Uri photoUri;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edit_picture);
        mImageView = (ImageView) findViewById(R.id.picture_id);
        btn = (Button) findViewById(R.id.edit_picture);
        savebtn = (Button) findViewById(R.id.save_picture);
        btn.setEnabled(false);
        savebtn.setEnabled(false);

    }

    @RequiresApi(api = Build.VERSION_CODES.M)
    public void getPicture(View view){
        if (ContextCompat.checkSelfPermission(getApplicationContext(), Manifest.permission.CAMERA)
                == PackageManager.PERMISSION_DENIED){
            requestPermissions(new String[] {Manifest.permission.CAMERA}, MY_CAMERA_REQUEST_CODE);
        }
        else{
            dispatchTakePictureIntent();
        }


    }
    @TargetApi(Build.VERSION_CODES.N)
    @RequiresApi(api = Build.VERSION_CODES.N)
    private void dispatchTakePictureIntent(){
        Intent takePictureIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        File file = null;
        try{
            file = createImageFile();
        } catch (IOException e) {
            e.printStackTrace();
        }
        if(file != null){
            photoUri = FileProvider.getUriForFile(this, "at.technikum_wien.fileprovider", file);
            takePictureIntent.putExtra(MediaStore.EXTRA_OUTPUT, photoUri);
            if (takePictureIntent.resolveActivity(getPackageManager()) != null) {
                startActivityForResult(takePictureIntent, REQUEST_IMAGE_CAPTURE);
            }
        }

    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    private File createImageFile() throws IOException {
        String timeStamp;
        timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());
        File storageDir = getExternalFilesDir(Environment.DIRECTORY_PICTURES);
        File image = File.createTempFile(timeStamp, ".jpg", storageDir);

        mCurrentPhotoPath = image.getAbsolutePath();
        return image;
    }

    private void setClicked(){
        if(clicked){
            clicked = false;
            btn.setText("Edit Picture");
        }
        else if(clicked == false){
            clicked = true;
            btn.setText("Cancel");
        }
    }

    public void editPicture(View view){
        editstartTime = System.currentTimeMillis();
        setClicked();
        if(clicked){
            BitmapDrawable drawable = (BitmapDrawable) mImageView.getDrawable();
            Bitmap bitmap = drawable.getBitmap();
            mImageView.setColorFilter(pictureEditor.grayScaleBitMap(bitmap));
        }
        else{
            mImageView.clearColorFilter();
        }

        long stopTime = System.currentTimeMillis();
        long elapsedTime = stopTime - editstartTime;
        Log.d("editpictureactivity",  "Edit: "+String.valueOf(elapsedTime*0.001)+" seconds");
    }

    @RequiresApi(api = Build.VERSION_CODES.M)
    public void savePicture(View view){
        startTime = System.currentTimeMillis();

        if(ContextCompat.checkSelfPermission(getApplicationContext(), Manifest.permission.WRITE_EXTERNAL_STORAGE) ==
                PackageManager.PERMISSION_DENIED){
            requestPermissions(new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
                    MY_WRITE_STORAGE_REQUEST_CODE);
        }
        else
            {
            long milliseconds = System.currentTimeMillis();

            BitmapDrawable drawable = (BitmapDrawable) mImageView.getDrawable();
            Bitmap bitmap = drawable.getBitmap();

            if(clicked){
                bitmap = UseCanvas(bitmap);
            }

            saveBitmap(bitmap, String.valueOf(milliseconds));

        }
    }

    private Bitmap UseCanvas(Bitmap original){
        Bitmap bitmap = Bitmap.createBitmap(original.getWidth(), original.getHeight(), Bitmap.Config.ARGB_8888);
        Canvas canvas = new Canvas(bitmap);

        Paint paint = new Paint();
        ColorMatrix cm = new ColorMatrix();
        cm.setSaturation(0);
        paint.setColorFilter(new ColorMatrixColorFilter(cm));
        canvas.drawBitmap(original, 0, 0, paint);

        return bitmap;
    }

    private void saveBitmap(Bitmap bitmap, String filename){
        File file;
        String path = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_PICTURES).toString();
        file = new File(path, filename+".jpg");

        try{
            OutputStream stream = null;
            stream = new FileOutputStream(file);

            bitmap.compress(Bitmap.CompressFormat.JPEG,100,stream);
            stream.flush();
            stream.close();


        } catch (IOException e) {
            e.printStackTrace();
        }

        Uri savedImageURI = Uri.parse(file.getAbsolutePath());

        long stopTime = System.currentTimeMillis();
        long elapsedTime = stopTime - startTime;
        Log.d("editpictureactivity", "Save: "+String.valueOf(elapsedTime*0.001)+" seconds");
    }


    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data){
        if(requestCode == REQUEST_IMAGE_CAPTURE && resultCode == RESULT_OK){

           // Bundle extras = data.getExtras();
           // Bitmap imagebitmap = (Bitmap) extras.get("data");
            //mImageView.setImageBitmap(imagebitmap);
            this.grabImage();
            btn.setEnabled(true);
            savebtn.setEnabled(true);
        }
    }

    public void grabImage(){
        this.getContentResolver().notifyChange(photoUri, null);
        ContentResolver cr = this.getContentResolver();
        Bitmap bitmap;
        try
        {
            bitmap = android.provider.MediaStore.Images.Media.getBitmap(cr, photoUri);
            Bitmap b = Bitmap.createScaledBitmap(bitmap, bitmap.getWidth()/4, bitmap.getHeight()/4, true);
            mImageView.setImageBitmap(b);
            bitmap = null;
        }
        catch (Exception e)
        {
            Toast.makeText(this, "Failed to load", Toast.LENGTH_SHORT).show();
            Log.d("save", "Failed to load", e);
        }
    }
}
