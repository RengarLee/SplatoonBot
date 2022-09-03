using System.Text.Json.Serialization;

namespace SplatoonBot.Event;

public class GeneralEvent
{
    /// <summary>
    ///     事件发生的时间戳
    /// </summary>
    [JsonPropertyName("time")]
    public long Timestamp { get; set; }

    [JsonIgnore] public DateTime Time => TimeExtension.UnixTimeStampToDateTime(Timestamp);

    /// <summary>
    ///     收到事件的机器人 QQ 号
    /// </summary>
    [JsonPropertyName("self_id")]
    public long SelfId { get; set; }

    /// <summary>
    ///     上报类型
    /// </summary>
    [JsonPropertyName("post_type")]
    public string PostType { get; set; }

    /// <summary>
    ///     消息类型
    /// </summary>
    [JsonPropertyName("message_type")]
    public string MessageType { get; set; }

    /// <summary>
    ///     消息子类型, 正常消息是 normal, 匿名消息是 anonymous, 系统提示 ( 如「管理员已禁止群内匿名聊天」 ) 是 notice
    /// </summary>
    [JsonPropertyName("sub_type")]
    public string SubType { get; set; }

    /// <summary>
    ///     消息 ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public int MessageId { get; set; }

    /// <summary>
    ///     发送者 QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    ///     原始消息内容
    /// </summary>
    public List<Message> Message { get; set; }

    /// <summary>
    ///     原始消息内容
    /// </summary>
    [JsonPropertyName("raw_message")]
    public string RawMessage { get; set; }

    /// <summary>
    ///     字体
    /// </summary>
    public int Font { get; set; }

    /// <summary>
    ///     群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }


    public bool IsGroupMessage()
    {
        return PostType.Equals("message") && MessageType.Equals("group");
    }
}