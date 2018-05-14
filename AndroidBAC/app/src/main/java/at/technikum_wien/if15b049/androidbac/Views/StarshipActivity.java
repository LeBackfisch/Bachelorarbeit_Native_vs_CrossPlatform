package at.technikum_wien.if15b049.androidbac.Views;


import android.os.Bundle;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.Loader;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.View;

import java.util.ArrayList;
import java.util.List;

import at.technikum_wien.if15b049.androidbac.R;
import at.technikum_wien.if15b049.androidbac.data.Starship;
import at.technikum_wien.if15b049.androidbac.data.StarshipAdapter;
import at.technikum_wien.if15b049.androidbac.data.StarshipLoader;

public class StarshipActivity extends AppCompatActivity implements LoaderManager.LoaderCallbacks<List<Starship>> {

    List<Starship> starships = new ArrayList<>();
    private static final int loader_id = 1;
    private long startTime = 0;
    private RecyclerView mRecyclerView;
    private StarshipAdapter mAdapter;
    private RecyclerView.LayoutManager mLayoutManager;


    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_starship);
        mRecyclerView = (RecyclerView) findViewById(R.id.starship_view);

        mLayoutManager = new LinearLayoutManager(this);
        mRecyclerView.setLayoutManager(mLayoutManager);

        mAdapter = new StarshipAdapter(starships);
        mRecyclerView.setAdapter(mAdapter);

    }

    public void getStarships(View view){
        startTime = System.currentTimeMillis();
        getSupportLoaderManager().initLoader(loader_id, null, this);
    }

    @Override
    public Loader<List<Starship>> onCreateLoader(int id, Bundle args) {
        return new StarshipLoader(getApplicationContext());
    }

    @Override
    public void onLoadFinished(Loader<List<Starship>> loader, List<Starship> data) {
    starships = data;
    long stopTime = System.currentTimeMillis();
    long elapsedTime = stopTime - startTime;
        mAdapter.updateDataSet(data);
        Log.d("starshipactivity", String.valueOf(elapsedTime*0.001)+" seconds");
    }

    @Override
    public void onLoaderReset(Loader<List<Starship>> loader) {

    }
}
