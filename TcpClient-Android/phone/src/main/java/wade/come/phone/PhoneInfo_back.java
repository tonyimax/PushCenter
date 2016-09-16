package wade.come.phone;

import android.app.Notification;
import android.app.NotificationManager;
import android.content.Context;
import android.graphics.BitmapFactory;
import android.net.wifi.WifiInfo;
import android.net.wifi.WifiManager;
import android.provider.Settings;
import android.telephony.TelephonyManager;
import android.util.Log;

import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.LineNumberReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.Socket;
import java.net.SocketException;
import java.net.UnknownHostException;
import java.util.Enumeration;

/**
 * @author Administrator
 * @version $Rev$
 * @time 2016-9-8 17:18
 * @des ${TODO}
 * @updateAuthor $Author$
 * @updateDate $Date$
 * @updateDes ${TODO}
 */
public class PhoneInfo_back {

    private TelephonyManager telephonyManager;
    /**
     * 国际移动用户识别码
     */
    private String IMSI;
    private Context cxt;
    public Socket mClientSocket;

    public PhoneInfo_back(Context context) throws IOException {
        cxt = context;
        telephonyManager = (TelephonyManager) context
                .getSystemService(Context.TELEPHONY_SERVICE);
    }

    /**
     * 获取电话号码
     */
    public String getNativePhoneNumber() {
        String NativePhoneNumber = null;
        NativePhoneNumber = telephonyManager.getLine1Number();
        return NativePhoneNumber;
    }

    /**
     * 获取手机服务商信息
     */
    public String getProvidersName() {
        String ProvidersName = "N/A";
        try {
            IMSI = telephonyManager.getSubscriberId();
            // IMSI号前面3位460是国家，紧接着后面2位00 02是中国移动，01是中国联通，03是中国电信。
            System.out.println(IMSI);
            if (IMSI.startsWith("46000") || IMSI.startsWith("46002")) {
                ProvidersName = "中国移动";
            } else if (IMSI.startsWith("46001")) {
                ProvidersName = "中国联通";
            } else if (IMSI.startsWith("46003")) {
                ProvidersName = "中国电信";
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return ProvidersName;
    }


    public String getPhoneInfo() {
        TelephonyManager tm = (TelephonyManager) cxt.getSystemService(Context.TELEPHONY_SERVICE);
        StringBuilder sb = new StringBuilder();

        sb.append("\nDeviceId(IMEI) = " + tm.getDeviceId());
        sb.append("\nDeviceSoftwareVersion = " + tm.getDeviceSoftwareVersion());
        sb.append("\nLine1Number = " + tm.getLine1Number());
        sb.append("\nNetworkCountryIso = " + tm.getNetworkCountryIso());
        sb.append("\nNetworkOperator = " + tm.getNetworkOperator());
        sb.append("\nNetworkOperatorName = " + tm.getNetworkOperatorName());
        sb.append("\nNetworkType = " + tm.getNetworkType());
        sb.append("\nPhoneType = " + tm.getPhoneType());
        sb.append("\nSimCountryIso = " + tm.getSimCountryIso());
        sb.append("\nSimOperator = " + tm.getSimOperator());
        sb.append("\nSimOperatorName = " + tm.getSimOperatorName());
        sb.append("\nSimSerialNumber = " + tm.getSimSerialNumber());
        sb.append("\nSimState = " + tm.getSimState());
        sb.append("\nSubscriberId(IMSI) = " + tm.getSubscriberId());
        sb.append("\nVoiceMailNumber = " + tm.getVoiceMailNumber());
        return sb.toString();
    }


    private String getMac() {
        String macSerial = null;
        String str = "";

        try {
            Process pp = Runtime.getRuntime().exec("cat /sys/class/net/wlan0/address ");
            InputStreamReader ir = new InputStreamReader(pp.getInputStream());
            LineNumberReader input = new LineNumberReader(ir);
            char[] mac = new char[100];
            input.read(mac, 0, 100);
            macSerial = new String(mac).trim();
        } catch (IOException ex) {
            // 赋予默认值
            ex.printStackTrace();
        }
        return macSerial;
    }


    public void connect() {
/* * * * * * * * * * 客户端 Socket 通过构造方法连接服务器 * * * * * * * * * */
        try {
        mClientSocket = new Socket("192.168.1.102", 4530);
            // 客户端 Socket 可以通过指定 IP 地址或域名两种方式来连接服务器端,实际最终都是通过 IP 地址来连接服务器
            // 新建一个Socket，指定其IP地址及端口号
            // 客户端socket在接收数据时，有两种超时：1. 连接服务器超时，即连接超时；2. 连接服务器成功后，接收服务器数据超时，即接收超时
            // 设置 socket 读取数据流的超时时间
            mClientSocket.setSoTimeout(5000);
            // 发送数据包，默认为 false，即客户端发送数据采用 Nagle 算法；
            // 但是对于实时交互性高的程序，建议其改为 true，即关闭 Nagle 算法，客户端每发送一次数据，无论数据包大小都会将这些数据发送出去
            mClientSocket.setTcpNoDelay(true);
            // 设置客户端 socket 关闭时，close() 方法起作用时延迟 30 秒关闭，如果 30 秒内尽量将未发送的数据包发送出去
            mClientSocket.setSoLinger(true, 30);
            // 设置输出流的发送缓冲区大小，默认是4KB，即4096字节
            mClientSocket.setSendBufferSize(4096);
            // 设置输入流的接收缓冲区大小，默认是4KB，即4096字节
            mClientSocket.setReceiveBufferSize(4096);
            // 作用：每隔一段时间检查服务器是否处于活动状态，如果服务器端长时间没响应，自动关闭客户端socket
            // 防止服务器端无效时，客户端长时间处于连接状态
            mClientSocket.setKeepAlive(true);

            //接收服务器数据
            InputStream isGet = mClientSocket.getInputStream();
            InputStreamReader reader = new InputStreamReader(isGet, "UTF-8");

            char[] idata = new char[1000];
            reader.read(idata, 0, 1000);
            String str = new String(idata);
            System.out.println(str.trim() + "打印出得到的数据字符串");

            ShowNotification(str);

            // 客户端向服务器端发送数据，获取客户端向服务器端输出流
            OutputStream osSend = mClientSocket.getOutputStream();
            OutputStreamWriter osWrite = new OutputStreamWriter(osSend);
            BufferedWriter bufWrite = new BufferedWriter(osWrite);
            // 代表可以立即向服务器端发送单字节数据
            mClientSocket.setOOBInline(true);
            // 数据不经过输出缓冲区，立即发送
            mClientSocket.sendUrgentData(0x44);//"D"
            // 向服务器端写数据，写入一个缓冲区
            // 注：此处字符串最后必须包含“\r\n\r\n”，告诉服务器HTTP头已经结束，可以处理数据，否则会造成下面的读取数据出现阻塞
            // 在write() 方法中可以定义规则，与后台匹配来识别相应的功能，例如登录Login() 方法，可以写为write("Login|LeoZheng,0603 \r\n\r\n"),供后台识别;


            bufWrite.write("手机MAC:" + getDeviceMac() + " IP: " + getLocalIpAddress() + " \r\n\r\n");
            // 发送缓冲区中数据 - 前面说调用 flush() 无效，可能是调用的方法不对吧！
            bufWrite.flush();
        } catch (UnknownHostException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

    }

    public void ShowNotification(String content) {

        NotificationManager manager = (NotificationManager) cxt.getSystemService(cxt.NOTIFICATION_SERVICE);
        Notification.Builder builder = new Notification.Builder(cxt.getApplicationContext());
        builder.setContentTitle("TcpServerNotification");
        builder.setContentText(content);
        builder.setSmallIcon(R.mipmap.ic_launcher);
        builder.setLargeIcon(BitmapFactory.decodeResource(cxt.getResources(), R.mipmap.ic_launcher));
        Notification noti = builder.build();
        manager.notify(10, noti);
    }

    /**
     * IP V6 地址
     *
     * @return
     */
    public String getLocalIpAddress() {
        try {
            for (Enumeration<NetworkInterface> en = NetworkInterface.getNetworkInterfaces(); en.hasMoreElements(); ) {
                NetworkInterface intf = en.nextElement();
                for (Enumeration<InetAddress> enumIpAddr = intf.getInetAddresses(); enumIpAddr.hasMoreElements(); ) {
                    InetAddress inetAddress = enumIpAddr.nextElement();
                    if (!inetAddress.isLoopbackAddress()) {
                        return inetAddress.getHostAddress().toString();
                    }
                }
            }
        } catch (SocketException ex) {
            Log.e("IP:", ex.toString());
        }
        return null;
    }

    /**
     * MAC 地址
     *
     * @return
     */
    public String getDeviceMac() {
        WifiManager wifi = (WifiManager) cxt.getSystemService(Context.WIFI_SERVICE);
        WifiInfo info = wifi.getConnectionInfo();
        return info.getMacAddress();
    }

    public String getAndroidId() {
        String androidId = null;
        androidId = (Settings.Secure.getString(cxt.getContentResolver(), Settings.Secure.ANDROID_ID));


        return androidId;
    }
}


