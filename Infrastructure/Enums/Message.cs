
namespace Infrastructure.Enums
{
    public enum Alert
    {
        ALLFieldsRequired,
        StarFieldsRequired,
        PassNotEqualToRepass,
        SuccessRegister,
        SuccessInsert, SuccessUpdate, SuccessDelete, SuccessAccept, SuccessDecline, SuccessPending,
        NotAccessAdmin, NotAccessUser,
        ErrorInSystem, ErrorSameEmail, ErrorInInsert, ErrorInUpdate, ErrorInDelete, ErrorInInsertOrUpdate, ErrorInDeleteOrUpdate, ErrorInInputParameter,
        ErrorInValidInputData,
        ErrorInTypingData,
        ErrorTypingDataIsOutOfRanges,
        ErrorInImageResizer,
        ErrorInMailSender,
        ErrorInGettingData,
        ErrorChoosePic,
        ErrorChooseDoc,
        ErrorChooseZip,
        ErrorInvalidAnimatedPicExt,
        ErrorInvalidFileExt,
        ErrorInvalidPicExt,
        ErrorInvalidDocExt,
        ErrorInvalidZipExt,
        ErrorInPicLen,
        ErrorOutputIsEmpty,
        ErrorInSearch,
        NewsLetterSended,
        ErrorInRss,
        ErrorInDeleteOrSet,
        SuccessSetGalleryCover,
        SuccessRefresh,
        ErrorInRefresh,
        ErrorNoCity,
        ErrorNoCountry,
        ErrorEmptyBasket,
        ErrorNotAcceptPayToGetCard,
        ErrorEndCapacity,
        ErrorHaveChild,
        ErrorSameUser,
        ErrorCityHaveMember,
        ErrorInputOneTBox,
        ErrorOldPassword,
        ErrorCantDelete,
        ErrorDeleteSubset,
        ErrorDeleteOrActive,
        ErrorUsernameMistake
    };

    public enum AlertType
    {
        success = 1,
        info = 2,
        warning = 3,
        danger = 4,
        primary = 5,
        secondary = 6,
        dark = 7,
        light = 8
    }

    public static class Message
    {
        private static string ValidPicExt { get { return "jpg, jpeg, bmp"; } }

        private static string ValidAnimatedPicExt { get { return "jpg, bmp, png , gif, ico"; } }

        private static string ValidDocExt { get { return "pdf"; } }

        private static string ValidZipExt { get { return "rar, zip"; } }

        private static string ValidFileExt { get { return "pdf, jpg, jpeg, png, gif, flv, zip, rar"; } }

        public static string GetMessage(this Alert alert, int number = 0)
        {
            string message = string.Empty;

            switch (alert)
            {
                case Alert.ALLFieldsRequired: message = "پر کردن تمامی فیلد ها الزامی است."; break;
                case Alert.StarFieldsRequired: message = "پر کردن فیلد های ستاره دار الزامی است."; break;
                case Alert.PassNotEqualToRepass: message = "کلمه عبور و تکرار کلمه عبور یکسان نیست."; break;
                case Alert.SuccessRegister: message = "ثبت نام با موفقیت انجام شد."; break;
                case Alert.SuccessInsert: message = "اطلاعات با موفقیت ثبت شد."; break;
                case Alert.SuccessUpdate: message = "اطلاعات با موفقیت ویرایش شد."; break;
                case Alert.SuccessDelete: message = "اطلاعات با موفقیت حذف شد."; break;
                case Alert.NotAccessAdmin: message = "کاربر محترم ، شما دسترسی لازم جهت انجام این عملیات را ندارید ؛ لطفا از طریق دکمه خروج به صفحه ورود بازگشته و مجددا لاگین نمایید."; break;
                case Alert.NotAccessUser: message = "کاربر محترم ، شما دسترسی لازم جهت انجام این عملیات را ندارید ؛ لطفا از طریق دکمه خروج به صفحه اصلی سایت بازگشته و مجددا لاگین نمایید."; break;
                case Alert.ErrorInSystem: message = "مشکلی در سیستم رخ داده است."; break;
                case Alert.ErrorSameEmail: message = "این آدرس ایمیل قبلا ثبت در سایت شده است."; break;
                case Alert.ErrorInInsert: message = "مشکلی در سیستم ثبت رخ داده است."; break;
                case Alert.ErrorInUpdate: message = "مشکلی در سیستم ویرایش رخ داده است."; break;
                case Alert.ErrorInDelete: message = "آیتم دارای زیرمجموعه می باشد، لذا حذف آن امکان پذیر نیست."; break;
                case Alert.ErrorInDeleteOrSet: message = "مشکلی در سیستم حذف/ست رخ داده است."; break;
                case Alert.ErrorInDeleteOrUpdate: message = "مشکلی در سیستم حذف/ویرایش رخ داده است."; break;
                case Alert.ErrorInInsertOrUpdate: message = "مشکلی در سیستم ثبت/ویرایش رخ داده است."; break;
                case Alert.ErrorInInputParameter: message = "پارامترهای ورودی نادرست است"; break;
                case Alert.ErrorInTypingData: message = "مقدار وارد شده نادرست است."; break;
                case Alert.ErrorInValidInputData: message = "مقدار وارد شده غیر مجاز است."; break;
                case Alert.ErrorTypingDataIsOutOfRanges: message = "مقدار وارد شده بیش از حد مجاز است."; break;
                case Alert.ErrorInImageResizer: message = "مشکلی در سیستم ریسایزر رخ داده است."; break;
                case Alert.ErrorInMailSender: message = "مشکلی در سیستم ارسال ایمیل رخ داده است."; break;
                case Alert.ErrorInGettingData: message = "مشکلی در دریافت اطلاعات رخ داده است"; break;
                case Alert.ErrorChoosePic: message = "انتخاب تصویر الزامی است."; break;
                case Alert.ErrorChooseDoc: message = "انتخاب فایل متنی الزامی است."; break;
                case Alert.ErrorChooseZip: message = "انتخاب فایل فشرده الزامی است."; break;
                case Alert.ErrorInvalidAnimatedPicExt: message = string.Format("فرمت فایل تصویر غیرمجاز است.<br/>(فرمت های مجاز: {0})", ValidAnimatedPicExt); break;
                case Alert.ErrorInvalidPicExt: message = string.Format("فرمت فایل تصویر غیرمجاز است.<br/> (فرمت های مجاز: {0})", ValidPicExt); break;
                case Alert.ErrorInvalidDocExt: message = string.Format("فرمت فایل متنی غیرمجاز است.<br/> (فرمت های مجاز: {0})", ValidDocExt); break;
                case Alert.ErrorInvalidZipExt: message = string.Format("فرمت فایل فشرده غیرمجاز است.<br/> (فرمت های مجاز: {0})", ValidZipExt); break;
                case Alert.ErrorInvalidFileExt: message = string.Format("فرمت فایل غیرمجاز است.<br/> (فرمت های مجاز: {0})", ValidFileExt); break;
                case Alert.ErrorInPicLen: message = "حجم تصویر بیش از حد مجاز است."; break;
                case Alert.ErrorOutputIsEmpty: message = "موردی یافت نشد."; break;
                case Alert.ErrorInSearch: message = "مشکلی در سیستم جستجو رخ داده است."; break;
                case Alert.NewsLetterSended: message = string.Format("تعداد {0} خبرنامه ارسال گردید.", number); break;
                case Alert.SuccessRefresh: message = "به روز رسانی با موفقیت انجام شد"; break;
                case Alert.ErrorInRefresh: message = "مشکلی در سیستم به روزرسانی رخ داد ه است."; break;
                case Alert.SuccessAccept: message = "اطلاعات با موفقیت تایید شد."; break;
                case Alert.SuccessDecline: message = "اطلاعات با موفقیت رد شد."; break;
                case Alert.SuccessPending: message = "اطلاعات با موفقیت در انتظار تایید شد."; break;
                case Alert.ErrorSameUser: message = "نام کاربری انتخابی شما قبلا در سیستم ثبت شده است ، لطفا نام کاربری دیگری برگزینید."; break;
                case Alert.ErrorInputOneTBox: message = "حداقل باید یکی از فیلدها را پر نمایید."; break;
                case Alert.ErrorHaveChild: message = "این گزینه دارای زیر مجموعه می باشد ، لذا حذف آن میسر نیست."; break;
                case Alert.ErrorOldPassword: message = "رمز عبور قبلی اشتباه است."; break;
                case Alert.ErrorCantDelete: message = "این شخص قابل حذف نمی باشد."; break;
                case Alert.ErrorDeleteSubset: message = "این شخص زیرمجموعه دارد و سیستم قادر به حذف نیست."; break;
                case Alert.ErrorDeleteOrActive: message = "شما مجاز به حذف این شخص نیستید این شخص فعال می باشد و فقط مدیر سیستم مجاز به حذف می باشد."; break;
                case Alert.SuccessSetGalleryCover: message = "کاور گالری با موفقیت تنظیم شد."; break;
                case Alert.ErrorUsernameMistake: message = "نام کاربری یا کلمه عبور اشتباه است."; break;

                default:
                    message = "پیام مورد نظر یافت نشد!";
                    break;
            }


            return message;

        }
    }
}