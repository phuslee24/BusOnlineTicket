import { TOKEN, USER_LOGIN } from "../../util/settings/config";
import { DANG_NHAP_ACTION, GET_DRIVER_LIST, LAY_CHI_TIET_NGUOI_DUNG, LAY_DANH_SACH_NGUOI_DUNG, SET_THONG_TIN_DAT_VE, TIM_KIEM_NGUOI_DUNG } from "../constants"

let user = {}
if (localStorage.getItem(USER_LOGIN)) {
  user = JSON.parse(localStorage.getItem(USER_LOGIN))
}



const initialState = {
  userLogin: user,
  thongTinNguoiDung: {},
  chiTietNguoiDung: {},
  arrUser: [
    // {
    //   "taiKhoan": "01Admin123",
    //   "hoTen": "Tung Son",
    //   "email": "thong000@gmail.com",
    //   "soDt": "0987654321",
    //   "matKhau": "iphone12",
    //   "maLoaiNguoiDung": "QuanTri"
    // }
  ],
  arrDriver: [],
  profile: {}
}


export const UserReducer = (state = initialState, action) => {
  switch (action.type) {

    case DANG_NHAP_ACTION:
      const { thongTinDangNhap } = action;
      localStorage.setItem(USER_LOGIN, JSON.stringify(thongTinDangNhap.content));
      localStorage.setItem(TOKEN, thongTinDangNhap.accessToken);
      return { ...state, userLogin: thongTinDangNhap.content }

    case GET_DRIVER_LIST:
      state.arrDriver = action.arrDriver;
      return { ...state }

    case LAY_CHI_TIET_NGUOI_DUNG:
      state.profile = action.profile;
      
      return { ...state }

    case SET_THONG_TIN_DAT_VE:
      state.thongTinNguoiDung = action.thongTinNguoiDung;
      return { ...state }
    default:
      return state
  }
}
