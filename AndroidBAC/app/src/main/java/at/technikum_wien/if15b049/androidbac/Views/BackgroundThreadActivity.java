package at.technikum_wien.if15b049.androidbac.Views;

import android.os.Build;
import android.os.Bundle;
import android.support.annotation.RequiresApi;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.Loader;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.TextView;

import at.technikum_wien.if15b049.androidbac.R;
import at.technikum_wien.if15b049.androidbac.data.Prime;
import at.technikum_wien.if15b049.androidbac.data.PrimeLoader;

public class BackgroundThreadActivity extends AppCompatActivity  implements LoaderManager.LoaderCallbacks<Prime>
{
    private double pi;
    private static final int bg_loader_id = 2;
    private long startTime = 0;
    TextView result;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_background_thread);


    }

    public void startThread(View view){
        startTime = System.currentTimeMillis();
        getSupportLoaderManager().initLoader(bg_loader_id, null, this);



    }


    @RequiresApi(api = Build.VERSION_CODES.N)
    @Override
    public Loader<Prime> onCreateLoader(int id, Bundle args) {
        return new PrimeLoader(getApplicationContext());

    }

    @Override
    public void onLoadFinished(Loader<Prime> loader, Prime data) {
        pi = data.GetPi();
        long stopTime = System.currentTimeMillis();
        long elapsedTime = stopTime - startTime;
        Log.d("BackgroundThread",String.valueOf(elapsedTime*0.001)+" seconds");
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                result = (TextView) findViewById(R.id.thread_result);
                result.setText(String.valueOf(pi));
            }
        });
    }

    @Override
    public void onLoaderReset(Loader loader) {

    }

}


