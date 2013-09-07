using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.NET
{
    public enum ButtonGroupSize
    {
        [Render("")] Default,
        [Render("btn-group-lg")] Large,
        [Render("btn-group-sm")] Small,
        [Render("btn-group-xs")] ExtraSmall
    }

    public enum ButtonSize
    {
        [Render("")] Default,
        [Render("btn-xs")] ExtraSmall,
        [Render("btn-sm")] Small,
        [Render("btn-lg")] Large
    }

    public enum ButtonStyle
    {
        [Render("btn-default")] Default,
        [Render("btn-primary")] Primary,
        [Render("btn-success")] Success,
        [Render("btn-info")] Info,
        [Render("btn-warning")] Warning,
        [Render("btn-danger")] Danger,
        [Render("btn-link")] Link
    }

    public enum DropdownDirection
    {
        [Render("")] Down,
        [Render("dropup")] Up 
    }

    public enum TextBoxMode
    {
        [Render("color")] Color,
        [Render("date")] Date,
        [Render("datetime")] DateTime,
        [Render("datetime-local")] DateTimeLocal,
        [Render("email")] Email,
        [Render("month")] Month,
        [Render("")] Multiline,
        [Render("number")] Number,
        [Render("password")] Password,
        [Render("tel")] Phone,
        [Render("range")] Range,
        [Render("search")] Search,
        [Render("text")] Singleline,
        [Render("time")] Time,
        [Render("url")] Url,
        [Render("week")] Week
    }

    public enum EventType
    {
        Login
    }

    public enum ButtonGroupDirection
    {
        [Render("btn-group")] Horizontal,
        [Render("btn-group-vertical")] Vertical,
    }

    public enum MenuItemType
    {
        [Render("")] Link,
        [Render("divider")] Divider,
        [Render("dropdown-header")] Header
    }

    public enum NavbarPosition
    {
        [Render("navbar-static-top")] StaticTop,
        [Render("navbar-fixed-top")] FixedTop,
        [Render("navbar-fixed-bottom")] FixedBottom        
    }

    public enum NavbarStyle
    {
        [Render("navbar-default")] Default,
        [Render("navbar-inverse")] Inverse
    }

    public enum PanelStyle
    {
        [Render("panel-default")] Default,
        [Render("panel-primary")] Primary,
        [Render("panel-success")] Success,
        [Render("panel-info")] Info,
        [Render("panel-warning")] Warning,
        [Render("panel-danger")] Danger
    }

    public enum Position
    {
        Left,
        Right
    }

    public enum ToggleEffect
    {
        [Render("")] None,
        [Render("fade")] Fade
    }

    public enum IconType
    {
        [Render("glyphicon-adjust")] Adjust,
        [Render("glyphicon-align-center")] AlignCenter,
        [Render("glyphicon-align-justify")] AlignJustify,
        [Render("glyphicon-align-left")] AlignLeft,
        [Render("glyphicon-align-right")] AlignRight,
        [Render("glyphicon-arrow-down")] ArrowDown,
        [Render("glyphicon-arrow-left")] ArrowLeft,
        [Render("glyphicon-arrow-right")] ArrowRight,
        [Render("glyphicon-arrow-up")] ArrowUp,
        [Render("glyphicon-asterisk")] Asterisk,
        [Render("glyphicon-backward")] Backward,
        [Render("glyphicon-ban-circle")] BanCircle,
        [Render("glyphicon-barcode")] Barcode,
        [Render("glyphicon-bell")] Bell,
        [Render("glyphicon-bold")] Bold,
        [Render("glyphicon-book")] Book,
        [Render("glyphicon-bookmark")] Bookmark,
        [Render("glyphicon-briefcase")] Briefcase,
        [Render("glyphicon-bullhorn")] Bullhorn,
        [Render("glyphicon-calendar")] Calendar,
        [Render("glyphicon-camera")] Camera,
        [Render("glyphicon-certificate")] Certificate,
        [Render("glyphicon-check")] Check,
        [Render("glyphicon-chevron-down")] ChevronDown,
        [Render("glyphicon-chevron-left")] ChevronLeft,
        [Render("glyphicon-chevron-right")] ChevronRight,
        [Render("glyphicon-chevron-up")] ChevronUp,
        [Render("glyphicon-circle-arrow-down")] CircleArrowDown,
        [Render("glyphicon-circle-arrow-left")] CircleArrowLeft,
        [Render("glyphicon-circle-arrow-right")] CircleArrowRight,
        [Render("glyphicon-circle-arrow-up")] CircleArrowUp,
        [Render("glyphicon-cloud")] Cloud,
        [Render("glyphicon-cloud-download")] CloudDownload,
        [Render("glyphicon-cloud-upload")] CloudUpload,
        [Render("glyphicon-cog")] Cog,
        [Render("glyphicon-collapse-down")] CollapseDown,
        [Render("glyphicon-collapse-up")] CollapseUp,
        [Render("glyphicon-comment")] Comment,
        [Render("glyphicon-compressed")] Compressed,
        [Render("glyphicon-copyright-mark")] CopyrightMark,
        [Render("glyphicon-credit-card")] CreditCard,
        [Render("glyphicon-cutlery")] Cutlery,
        [Render("glyphicon-dashboard")] Dashboard,
        [Render("glyphicon-download")] Download,
        [Render("glyphicon-download-alt")] DownloadAlt,
        [Render("glyphicon-earphone")] Earphone,
        [Render("glyphicon-edit")] Edit,
        [Render("glyphicon-eject")] Eject,
        [Render("glyphicon-envelope")] Envelope,
        [Render("glyphicon-euro")] Euro,
        [Render("glyphicon-exclamation-sign")] ExclamationSign,
        [Render("glyphicon-expand")] Expand,
        [Render("glyphicon-export")] Export,
        [Render("glyphicon-eye-close")] EyeClose,
        [Render("glyphicon-eye-open")] EyeOpen,
        [Render("glyphicon-facetime-video")] FacetimeVideo,
        [Render("glyphicon-fast-backward")] FastBackward,
        [Render("glyphicon-fast-forward")] FastForward,
        [Render("glyphicon-file")] File,
        [Render("glyphicon-film")] Film,
        [Render("glyphicon-filter")] Filter,
        [Render("glyphicon-fire")] Fire,
        [Render("glyphicon-flag")] Flag,
        [Render("glyphicon-flash")] Flash,
        [Render("glyphicon-floppy-disk")] FloppyDisk,
        [Render("glyphicon-floppy-open")] FloppyOpen,
        [Render("glyphicon-floppy-remove")] FloppyRemove,
        [Render("glyphicon-floppy-save")] FloppySave,
        [Render("glyphicon-floppy-saved")] FloppySaved,
        [Render("glyphicon-floppy-close")] FloppyClose,
        [Render("glyphicon-font")] Font,
        [Render("glyphicon-forward")] Forward,
        [Render("glyphicon-fullscreen")] Fullscreen,
        [Render("glyphicon-gbp")] GBP,
        [Render("glyphicon-gift")] Gift,
        [Render("glyphicon-glass")] Glass,
        [Render("glyphicon-globe")] Globe,
        [Render("glyphicon-hand-down")] HandDown,
        [Render("glyphicon-hand-left")] HandLeft,
        [Render("glyphicon-hand-right")] HandRight,
        [Render("glyphicon-hand-up")] HandUp,
        [Render("glyphicon-hd-video")] HDVideo,
        [Render("glyphicon-hdd")] HDD,
        [Render("glyphicon-header")] Header,
        [Render("glyphicon-headphones")] Headphones,
        [Render("glyphicon-heart")] Heart,
        [Render("glyphicon-heart-empty")] HeartEmpty,
        [Render("glyphicon-home")] Home,
        [Render("glyphicon-import")] Import,
        [Render("glyphicon-inbox")] Inbox,
        [Render("glyphicon-indent-left")] IndentLeft,
        [Render("glyphicon-indent-right")] IndentRight,
        [Render("glyphicon-info-sign")] InfoSign,
        [Render("glyphicon-italic")] Italic,
        [Render("glyphicon-leaf")] Leaf,
        [Render("glyphicon-link")] Link,
        [Render("glyphicon-list")] List,
        [Render("glyphicon-list-alt")] ListAlt,
        [Render("glyphicon-lock")] Lock,
        [Render("glyphicon-log-in")] Login,
        [Render("glyphicon-log-out")] LogOut,
        [Render("glyphicon-magnet")] Magnet,
        [Render("glyphicon-map-marker")] MapMarker,
        [Render("glyphicon-minus")] Minus,
        [Render("glyphicon-minus-sign")] MinusSign,
        [Render("glyphicon-move")] Move,
        [Render("glyphicon-music")] Music,
        [Render("glyphicon-new-window")] NewWindow,
        [Render("")] None,
        [Render("glyphicon-off")] Off,
        [Render("glyphicon-ok")] OK,
        [Render("glyphicon-ok-circle")] OKCircle,
        [Render("glyphicon-ok-sign")] OKSign,
        [Render("glyphicon-open")] Open,
        [Render("glyphicon-paperclip")] Paperclip,
        [Render("glyphicon-pause")] Pause,
        [Render("glyphicon-pencil")] Pencil,
        [Render("glyphicon-phone")] Phone,
        [Render("glyphicon-phone-alt")] PhoneAlt,
        [Render("glyphicon-picture")] Picture,
        [Render("glyphicon-plane")] Plane,
        [Render("glyphicon-play")] Play,
        [Render("glyphicon-play-circle")] PlayCircle,
        [Render("glyphicon-plus")] Plus,
        [Render("glyphicon-plus-sign")] PlusSign,
        [Render("glyphicon-print")] Print,
        [Render("glyphicon-pushpin")] Pushpin,
        [Render("glyphicon-qrcode")] QRCode,
        [Render("glyphicon-question-sign")] QuestionSign,
        [Render("glyphicon-random")] Random,
        [Render("glyphicon-record")] Record,
        [Render("glyphicon-refresh")] Refresh,
        [Render("glyphicon-registration-mark")] RegistrationMark,
        [Render("glyphicon-remove")] Remove,
        [Render("glyphicon-remove-circle")] RemoveCircle,
        [Render("glyphicon-remove-sign")] RemoveSign,
        [Render("glyphicon-repeat")] Repeat,
        [Render("glyphicon-resize-full")] ResizeFull,
        [Render("glyphicon-resize-horizontal")] ResizeHorizontal,
        [Render("glyphicon-resize-small")] ResizeSmall,
        [Render("glyphicon-resize-vertical")] ResizeVertical,
        [Render("glyphicon-retweet")] Retweet,
        [Render("glyphicon-road")] Road,
        [Render("glyphicon-save")] Save,
        [Render("glyphicon-saved")] Saved,
        [Render("glyphicon-screenshot")] Screenshot,
        [Render("glyphicon-sd-video")] SDVideo,
        [Render("glyphicon-search")] Search,
        [Render("glyphicon-send")] Send,
        [Render("glyphicon-share")] Share,
        [Render("glyphicon-share-alt")] ShareAlt,
        [Render("glyphicon-shopping-cart")] ShoppingCart,
        [Render("glyphicon-signal")] Signal,
        [Render("glyphicon-sort")] Sort,
        [Render("glyphicon-sort-by-alphabet")] SortByAlphabet,
        [Render("glyphicon-sort-by-alphabet-alt")] SortByAlphabetAlt,
        [Render("glyphicon-sort-by-attributes")] SortByAttributes,
        [Render("glyphicon-sort-by-attributes-alt")] SortByAttributesAlt,
        [Render("glyphicon-sort-by-order")] SortByOrder,
        [Render("glyphicon-sort-by-order-alt")] SortByAlt,
        [Render("glyphicon-sound-5-1")] Sound51,
        [Render("glyphicon-sound-6-1")] Sound61,
        [Render("glyphicon-sound-7-1")] Sound71,
        [Render("glyphicon-sound-dolby")] SoundDolby,
        [Render("glyphicon-sound-stereo")] SoundStereo,
        [Render("glyphicon-star")] Star,
        [Render("glyphicon-star-empty")] StarEmpty,
        [Render("glyphicon-stats")] Stats,
        [Render("glyphicon-step-backward")] StepBackward,
        [Render("glyphicon-step-forward")] StepForward,
        [Render("glyphicon-stop")] Stop,
        [Render("glyphicon-subtitles")] Subtitles,
        [Render("glyphicon-tag")] Tag,
        [Render("glyphicon-tags")] Tags,
        [Render("glyphicon-tasks")] Tasks,
        [Render("glyphicon-text-height")] TextHeight,
        [Render("glyphicon-text-width")] TextWidth,
        [Render("glyphicon-th")] Th,
        [Render("glyphicon-th-large")] ThLarge,
        [Render("glyphicon-th-list")] ThList,
        [Render("glyphicon-thumbs-down")] ThumbsDown,
        [Render("glyphicon-thumbs-up")] ThumbsUp,
        [Render("glyphicon-time")] Time,
        [Render("glyphicon-tint")] Tint,
        [Render("glyphicon-tower")] Tower,
        [Render("glyphicon-transfer")] Transfer,
        [Render("glyphicon-trash")] Trash,
        [Render("glyphicon-tree-conifer")] TreeConifer,
        [Render("glyphicon-tree-deciduous")] TreeDeciduous,
        [Render("glyphicon-unchecked")] Unchecked,
        [Render("glyphicon-upload")] Upload,
        [Render("glyphicon-usd")] USD,
        [Render("glyphicon-user")] User,
        [Render("glyphicon-volume-down")] VolumeDown,
        [Render("glyphicon-volume-off")] VolumeOff,
        [Render("glyphicon-volume-up")] VolumeUp,
        [Render("glyphicon-warning-sign")] WarningSign,
        [Render("glyphicon-wrench")] Wrench,
        [Render("glyphicon-zoom-in")] ZoomIn,
        [Render("glyphicon-zoom-out")] ZoomOut
    }
}
