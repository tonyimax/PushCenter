package wade.come.myapplication;

import android.app.Notification;
import android.app.NotificationManager;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.net.Socket;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    private static final String TAG = "MainActivity";
    private TextView mTv;
    private String mS;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Button bt = (Button) findViewById(R.id.button);
        mTv = (TextView) findViewById(R.id.tv);

        mTv.setText("nima");
        bt.setOnClickListener(this);
    }


    //    @Override
    public void onClick(View v) {

        new Thread() {
            @Override
            public void run() {
                super.run();
                System.out.println("4444");
                connect();
                System.out.println("5555");
            }

        }.start();

        NotificationManager manager = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);

        Notification noti = new Notification.Builder(this)
                .setContentTitle("这是6666666通知标题")
                .setContentText(mS + "中77777777国厨艺学院")
                .setSmallIcon(R.mipmap.ic_launcher)
                .setLargeIcon(BitmapFactory.decodeResource(getResources(), R.mipmap.ic_launcher))
                .build();

        manager.notify(10, noti);

    }

    private void connect() {

        Socket socket = null;
        try {
            socket = new Socket("10.0.2.2", 4530);
            BufferedReader br = new BufferedReader(new InputStreamReader(socket.getInputStream()));        //将字节流包装成了字符流
            char[] data = new char[1024];
            PrintStream ps = new PrintStream(socket.getOutputStream());
            br.read(data, 0, 1024);
            System.out.println(data);

            /**
             *
             *  基本代码
             */

            //            InputStream is = socket.getInputStream();			//获取客户端输入流
            //            OutputStream os = socket.getOutputStream();			//获取客户端的输出流



            //            byte[] arr = new byte[1024];
            //            int len = is.read(arr);								//读取服务器发过来的数据
            //            System.out.println(new String(arr,0,len));       	//将数据转换成字符串并打印 -=->>可以作为消息提醒
            //            os.write("学习挖掘机哪家强?".getBytes());

            ps.println("我想报名中国厨艺学院");// 发送模拟消息
            ps.println("大哭!!!死了都要爱");


            runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    mTv.setText(mS + "死了都要爱");
                }
            });

            socket.close();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
