package com.example.ldaviaud.tp1;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class SecondActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.second_activity);

        String t_nickname = savedInstanceState.getString("nickname");
        String t_firstname = savedInstanceState.getString("firstname");
        String t_age = savedInstanceState.getString("age");
        String t_skill = savedInstanceState.getString("skill");
        String t_phone_number = savedInstanceState.getString("phone_number");

        ((TextView) findViewById(R.id.second_activity_textview_1)).setText(t_nickname);
        ((TextView) findViewById(R.id.second_activity_textview_2)).setText(t_firstname);
        ((TextView) findViewById(R.id.second_activity_textview_3)).setText(t_age);
        ((TextView) findViewById(R.id.second_activity_textview_4)).setText(t_skill);
        ((TextView) findViewById(R.id.second_activity_textview_5)).setText(t_phone_number);

        ((Button) findViewById(R.id.second_activity_button_back)).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(getApplicationContext(), FirstActivity.class));
            }
        });

        ((Button) findViewById(R.id.second_activity_button_next)).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(getBaseContext(), ThirdActivity.class));
            }
        });

    }
}
