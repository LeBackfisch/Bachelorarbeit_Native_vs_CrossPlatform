package at.technikum_wien.if15b049.androidbac.data;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import at.technikum_wien.if15b049.androidbac.R;

/**
 * Created by Sebastian on 28.04.2018.
 */

public class StarshipAdapter extends RecyclerView.Adapter<StarshipAdapter.ItemViewHolder> {
    private List<Starship> mDataset = new ArrayList<>();

    public StarshipAdapter(List<Starship> data){
        mDataset = data;
    }

    class ItemViewHolder extends RecyclerView.ViewHolder {
        private TextView name;
        private TextView length;

        public ItemViewHolder(View itemView) {
            super(itemView);
            name = (TextView) itemView.findViewById(R.id.name);
            length = (TextView) itemView.findViewById(R.id.length);
        }
    }

    public void updateDataSet(List<Starship> starships){
        mDataset = starships;
        notifyDataSetChanged();
    }
    @Override
    public void onBindViewHolder(final StarshipAdapter.ItemViewHolder holder, final int position){
        Starship starship = mDataset.get(position);

        holder.name.setText("Name: "+starship.GetName());
        holder.length.setText("Length: "+String.valueOf(starship.GetLength()));

    }


    @Override
    public StarshipAdapter.ItemViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        Context context = parent.getContext();
        LayoutInflater inflater = LayoutInflater.from(context);
        View view = inflater.inflate(R.layout.starship_item, parent, false);
        return new ItemViewHolder(view);
    }

    @Override
    public int getItemCount() {
        return mDataset.size();
    }
}
