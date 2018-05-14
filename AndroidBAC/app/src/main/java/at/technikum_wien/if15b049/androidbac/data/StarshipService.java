package at.technikum_wien.if15b049.androidbac.data;

import android.os.Build;
import android.support.annotation.RequiresApi;
import android.util.JsonReader;
import android.util.Log;

import org.apache.commons.io.IOUtils;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Sebastian on 28.04.2018.
 */

public class StarshipService {

    private List<Starship> starshipList = new ArrayList<>();
        URLConnection urlConnection = null;
    String jsonString = "";

    public StarshipService(){

    }

    @RequiresApi(api = Build.VERSION_CODES.KITKAT)
    public List<Starship> GetStarships(){
        GetJSON();
        return starshipList;
    }

    @RequiresApi(api = Build.VERSION_CODES.KITKAT)
    private void GetJSON(){
    try{
        URL url = new URL("https://swapi.co/api/starships/?format=json");
        urlConnection = url.openConnection();
        InputStream in = urlConnection.getInputStream();
        starshipList.addAll(parseJSON(in));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
    }

    private List<Starship> parseJSON(InputStream in) throws IOException {
        JsonReader reader = new JsonReader(new InputStreamReader(in, "UTF-8"));
        try{
            return readJSON(reader);
        } finally {
            reader.close();
        }
    }

    private List<Starship> readJSON(JsonReader reader) throws IOException {
        List<Starship> starships = new ArrayList<Starship>();

        reader.beginObject();
        while(reader.hasNext()){
            String name = reader.nextName();
            if(name.equals("results")){
               starships = readResults(reader);
            }
            else{
                reader.skipValue();
            }

        }
        reader.endObject();

        return starships;

    }

    private List<Starship> readResults(JsonReader reader) throws IOException {
        List<Starship> starships = new ArrayList<>();
        reader.beginArray();
        while(reader.hasNext()){
            starships.add(readStarship(reader));
        }
        reader.endArray();
        return  starships;
    }

    private Starship readStarship(JsonReader reader) throws IOException {
        String name = "";
        String model = "";
        String manufacturer = "";
        double length = 0.f;

        reader.beginObject();
        while (reader.hasNext()){
            String varname = reader.nextName();
                if(varname.equals("name")){
                    name = reader.nextString();
                }
                else if(varname.equals("model")){
                    model = reader.nextString();
                }
                else if(varname.equals("manufacturer")){
                    manufacturer = reader.nextString();
                }
                else if(varname.equals("length")){
                    length = reader.nextDouble();
                }
                else{
                    reader.skipValue();
                }
            }
            reader.endObject();
            return new Starship(name, model, manufacturer, length);
        }



}


