package wade.come.phone;

import android.content.Intent;
import android.os.Bundle;
import android.provider.Settings;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

import wade.come.phone.service.MyService;

public class JinshanTestActivity extends AppCompatActivity implements View.OnClickListener {

    private PhoneInfo mSiminfo;
    private Button mBt;
    private Button mBt1;
    private Button mBt2;

    /**
     * Called when the activity is first created.
     */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


     /**  // 暂时不连接

       try {

            mSiminfo = new PhoneInfo(JinshanTestActivity.this);
        } catch (IOException e) {
            e.printStackTrace();
        }
        new Thread() {
            @Override
            public void run() {
                super.run();

                mSiminfo.connect();
            }
        }.start();*/

        mBt = (Button) findViewById(R.id.button);

        mBt1 = (Button) findViewById(R.id.button1);

        mBt2 = (Button) findViewById(R.id.button2);


        mBt.setOnClickListener(this);
        mBt1.setOnClickListener(this);
        mBt2.setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {

        Intent intent = new Intent(this, MyService.class);


        switch (v.getId()) {
            case R.id.button:

                new Thread() {
                    @Override
                    public void run() {
                        super.run();

                        try {
                            //接收服务器数据
                            InputStream isGet = mSiminfo.mClientSocket.getInputStream();
                            InputStreamReader reader = new InputStreamReader(isGet, "UTF-8");

                            char[] idata = new char[1000];
                            reader.read(idata, 0, 1000);
                            String str = new String(idata);
                            System.out.println(str.trim() + "打印出得到的数据字符串");

                            mSiminfo.ShowNotification(str);

                        } catch (IOException e) {
                            e.printStackTrace();
                        }

                    }
                }.start();

                System.out.println("===============================");
                System.out.println("序列号  --" + mSiminfo.getAndroidId());
                System.out.println("getProvidersName:" + mSiminfo.getProvidersName());
                System.out.println("getNativePhoneNumber:" + mSiminfo.getNativePhoneNumber());
                System.out.println("getPhoneInfo:" + mSiminfo.getPhoneInfo());
                System.out.println("----------序列号-头-----------");
                String androidId = null;
                androidId = Settings.Secure.getString(getContentResolver(), Settings.Secure.ANDROID_ID);
                System.out.println(androidId);
                System.out.println("-----------序列号--尾-----------");
                break;

            case R.id.button1:
                startService(intent);
                Toast.makeText(getApplicationContext(), "dianlestart", Toast.LENGTH_SHORT).show();

                break;
            case R.id.button2:
                stopService(intent);

                Toast.makeText(getApplicationContext(), "dianlestop", Toast.LENGTH_SHORT).show();
                break;


        }
    }

}


