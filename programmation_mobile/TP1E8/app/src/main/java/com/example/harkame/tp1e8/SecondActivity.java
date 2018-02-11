package com.example.harkame.tp1e8;

import android.app.Activity;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Spinner;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class SecondActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.second_activity);

        List<CharSequence> t_travels = new ArrayList<CharSequence>();
        t_travels.add("Paris - Tokyo");
        t_travels.add("New-York Pekin");
        t_travels.add("Montpellier - Nice");

        ListView t_spinner = (ListView) findViewById(R.id.list_view);

        ArrayAdapter<CharSequence> adapter2 = new ArrayAdapter<CharSequence>(
                this,
                android.R.layout.simple_spinner_dropdown_item, t_travels);

        t_spinner.setAdapter(adapter2);


    }
}
