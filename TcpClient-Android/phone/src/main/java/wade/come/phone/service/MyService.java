package wade.come.phone.service;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.Service;
import android.content.Intent;
import android.graphics.BitmapFactory;
import android.os.IBinder;
import android.support.annotation.Nullable;

import java.io.DataInputStream;
import java.io.IOException;
import java.net.Socket;

import wade.come.phone.R;

/**
 * @author Administrator
 * @version $Rev$
 * @time 2016-9-9 17:11
 * @des ${TODO}
 * @updateAuthor $Author$
 * @updateDate $Date$
 * @updateDes ${TODO}
 */
public class MyService extends Service {

    private boolean flag = false;

    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onCreate() {
        System.out.println("服务启动了  连接服务器-----");
        new Thread() {
            @Override
            public void run() {
                super.run();
                System.out.println("客户端启动...");
                Socket socket = null;
                try {
                    socket = new Socket("10.0.2.2", 4530);
//                    socket.setKeepAlive(true);
                } catch (IOException e) {
                    e.printStackTrace();
                }

                while (true) {
                    try {
                        //创建一个流套接字并将其连接到指定主机上的指定端口号
                        //读取服务器端数据
                        DataInputStream input = new DataInputStream(socket.getInputStream());

                        byte[] buffer;
                        buffer = new byte[input.available()];
                        if (buffer.length != 0) {
                            System.out.println("length=" + buffer.length);
                            // 读取缓冲区
                            input.read(buffer);
                            // 转换字符串
                            String three = new String(buffer);
                            System.out.println("内容=" + three);
                            showNotification(three);//弹出消息提醒
                        }
                    } catch (Exception e) {
                        System.out.println("客户端异常:" + e.getMessage());
                    }
                }
            }
        }.start();
        super.onCreate();
    }

    private void showNotification(String str) {

        NotificationManager manager = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
        Notification.Builder builder = new Notification.Builder(getApplicationContext());
        builder.setContentTitle("消息标题");
        builder.setContentText("消息内容-" + str);
        builder.setSmallIcon(R.mipmap.ic_launcher);
        builder.setLargeIcon(BitmapFactory.decodeResource(getResources(), R.mipmap.ic_launcher));
        Notification noti = builder.build();
        manager.notify(10, noti);
    }

    @Override
    public void onDestroy() {
        flag = false;
        super.onDestroy();
        System.out.println("服务销毁  ");
    }
}
/**




 */