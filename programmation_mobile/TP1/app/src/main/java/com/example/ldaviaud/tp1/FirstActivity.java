package com.example.ldaviaud.tp1;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;


public class FirstActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.first_activity);

        Button t_button = findViewById(R.id.button);


        final Context context = this;

        final String t_nick_name = ((EditText) findViewById(R.id.editText)).getText().toString();
        final String t_first_name = ((EditText) findViewById(R.id.editText2)).getText().toString();
        final String t_age = ((EditText) findViewById(R.id.editText3)).getText().toString();
        final String t_skill = ((EditText) findViewById(R.id.editText4)).getText().toString();
        final String t_phone_number = ((EditText) findViewById(R.id.editText5)).getText().toString();


        t_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AlertDialog.Builder builder;
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
                    builder = new AlertDialog.Builder(context, android.R.style.Theme_Material_Dialog_Alert);
                } else {
                    builder = new AlertDialog.Builder(context);
                }

                builder.setTitle("Confirmation")
                        .setMessage("Are you sure you want to delete this entry?")
                        .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {

                                Intent t_intent = new Intent(getBaseContext(), SecondActivity.class);

                                t_intent.putExtra("nickname", t_nick_name).
                                putExtra("firstname", t_first_name).
                                putExtra("age", t_age).
                                putExtra("skill", t_skill).
                                putExtra("phone_number", t_phone_number);

                                startActivity(t_intent);
                            }
                        })
                        .setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                // do nothing
                            }
                        })
                        .setIcon(android.R.drawable.ic_dialog_alert)
                        .show();
            }
        });


    }
}
