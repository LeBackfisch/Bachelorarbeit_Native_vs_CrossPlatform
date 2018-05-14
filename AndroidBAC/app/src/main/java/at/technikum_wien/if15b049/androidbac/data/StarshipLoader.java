package at.technikum_wien.if15b049.androidbac.data;

import android.os.Build;
import android.support.annotation.RequiresApi;
import android.support.v4.content.AsyncTaskLoader;
import android.content.Context;
import android.util.Log;

import java.util.List;

/**
 * Created by Sebastian on 28.04.2018.
 */

public class StarshipLoader extends AsyncTaskLoader<List<Starship>>{

    public StarshipLoader(Context context) {super(context);}

    private StarshipService starshipService = new StarshipService();
    @RequiresApi(api = Build.VERSION_CODES.KITKAT)
    @Override
    public List<Starship> loadInBackground() {
        Log.d("loader" ,"loading");
        return starshipService.GetStarships();
    }

    @Override
    protected void onStartLoading(){
        super.onStartLoading();
        forceLoad();
    }
}
