package com.example.ldaviaud.tp2;

import android.app.Activity;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

public class SecondActivity extends Activity {
    List<CharSequence> t_travels = new ArrayList<CharSequence>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.second_activty);

        t_travels.add(getIntent().getExtras().getString("firstname") + "_" + getIntent().getExtras().getString("lastname") + "_" + getIntent().getExtras().getString("phone_number"));

        ListView t_list_view = findViewById(R.id.list_view);

        ArrayAdapter<CharSequence> adapter = new ArrayAdapter<CharSequence>(
                this,
                android.R.layout.simple_spinner_dropdown_item, t_travels);

        t_list_view.setAdapter(adapter);
    }
}
