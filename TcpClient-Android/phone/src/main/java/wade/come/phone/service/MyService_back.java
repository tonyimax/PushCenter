package wade.come.phone.service;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.support.annotation.Nullable;

import java.io.IOException;

import wade.come.phone.PhoneInfo;

/**
 * @author Administrator
 * @version $Rev$
 * @time 2016-9-9 17:11
 * @des ${TODO}
 * @updateAuthor $Author$
 * @updateDate $Date$
 * @updateDes ${TODO}
 */
public class MyService_back extends Service {

    boolean flag = false;
    private PhoneInfo mSiminfo;


    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        //         在子线程    服务器 得到流 弹出消息    点击查看了  跳到主页面


        try {
            mSiminfo = new PhoneInfo(getApplicationContext());
        } catch (IOException e) {
            e.printStackTrace();
        }


        new Thread() {

            @Override
            public void run() {
                super.run();
                flag = true;

                    //            连接
                    System.out.println("服务启动了  连接服务器-----");

                    mSiminfo.connect();


            }
        }.start();

    }

    @Override
    public void onDestroy() {
        flag = false;
        super.onDestroy();
    }
}
