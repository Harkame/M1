package com.example.ldaviaud.tp2;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import org.w3c.dom.Text;

import java.io.FileOutputStream;

public class FirstActivity extends Activity {
    private int a_count = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_first);

        Button t_button = findViewById(R.id.button);

        t_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent t_intent = new Intent(FirstActivity.this, SecondActivity.class);


                t_intent.putExtra("firstname", ((EditText) findViewById(R.id.editText1)).getText().toString()).
                        putExtra("lastname", ((EditText) findViewById(R.id.editText2)).getText().toString()).
                        putExtra("phone_number", ((EditText) findViewById(R.id.editText3)).getText().toString());

                startActivity(t_intent);
            }
        });

        try {
            FileOutputStream t_file = openFileOutput("save", Context.MODE_PRIVATE);
            t_file.write("".getBytes());
            t_file.close();
        }
        catch(Exception t_exception)
        {

        }
    }

    @Override
    public void onResume()
    {
        super.onResume();

        ((TextView) findViewById(R.id.counter)).setText("" + a_count++);

    }
}
