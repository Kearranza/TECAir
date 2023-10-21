package com.example.tecair_app.register;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.example.tecair_app.db.comonClient;
import com.example.tecair_app.MainActivity;
import com.example.tecair_app.R;

public class userRegister extends AppCompatActivity{
    TextView Name, Lname, Lname2, user, Correo, Phone, Password, cedula;
    Button register;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_register);
        Name = findViewById(R.id.Name);
        Lname = findViewById(R.id.Lname);
        Lname2 = findViewById(R.id.Lname2);
        user = findViewById(R.id.user);
        Correo = findViewById(R.id.Correo);
        Phone = findViewById(R.id.Phone);
        Password = findViewById(R.id.Password);
        cedula = findViewById(R.id.cedula);
    }

    public void onClickBack(View view) {
        Intent intent = new Intent(this, registerAdmin.class);
        startActivity(intent);
    }

    public void onClickRegister(View view) {
        String name =  Name.getText().toString();
        String lname1 =  Lname.getText().toString();
        String lname2 =  Lname2.getText().toString();
        String username =  user.getText().toString();
        String email =  Correo.getText().toString();
        String cel =  Phone.getText().toString();
        String pword =  Password.getText().toString();
        String ssn = cedula.getText().toString();

        if(name.isEmpty()){
            Name.setError("Este campo no puede estar vacío");
            return;
        }
        if(lname1.isEmpty()){
            Lname.setError("Este campo no puede estar vacío");
            return;
        }   if(lname2.isEmpty()){
            Lname2.setError("Este campo no puede estar vacío");
            return;
        }  if(username.isEmpty()){
            user.setError("Este campo no puede estar vacío");
            return;
        }   if(email.isEmpty()){
            Correo.setError("Este campo no puede estar vacío");
            return;
        }  if(pword.isEmpty()){
            Password.setError("Este campo no puede estar vacío");
            return;
        }   if(cel.isEmpty()){
            Phone.setError("Este campo no puede estar vacío");
            return;
        }  if(ssn.isEmpty()){
            cedula.setError("Este campo no puede estar vacío");
            return;
        }
        comonClient client = new comonClient(username, name, lname1, lname2, email, cel, 0, Integer.valueOf(ssn), false);

        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }
}