package at.technikum_wien.if15b049.androidbac.Views;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;

import at.technikum_wien.if15b049.androidbac.R;

public class HomeActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

    }
      public void navigateStarship(View view){
        Intent intent = new Intent(this, StarshipActivity.class);
        startActivity(intent);
    }

    public void navigateEditPicture(View view){
        Intent intent = new Intent(this, EditPictureActivity.class);
        startActivity(intent);
    }

    public void navigateBackgroundThread(View view){
        Intent intent = new Intent(this, BackgroundThreadActivity.class);
        startActivity(intent);
    }



}
