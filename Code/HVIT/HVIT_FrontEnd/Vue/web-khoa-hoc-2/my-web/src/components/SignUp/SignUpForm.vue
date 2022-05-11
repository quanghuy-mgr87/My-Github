<template>
  <v-app id="screen">
    <v-container fluid style="margin: auto 0;">
      <v-row>
        <v-col cols="4"></v-col>
        <v-col cols="4" class="frmLogin pt-10">
          <h1>
            <v-avatar tile size="60" class="mr-3 mb-2"> <v-img src="../../logo/myLogo.png"></v-img> </v-avatar>
            <u> <span style="color: #1565C0">Y</span> <span style="color:#FF1744;">o</span> <span style="color:#76FF03;">U</span> </u>
          </h1>
          <ValidationObserver v-slot="{ handleSubmit }">
            <form @submit.prevent="handleSubmit(onSubmit)" class="px-11 mt-10">
              <ValidationProvider v-slot="{ errors }" name="Tài khoản" rules="required">
                <v-text-field label="Tên đăng nhập" color="indigo lighten-1" dark outlined :error-messages="errors" required v-model="user.TaiKhoan"></v-text-field>
                <p v-if="user_error != ''" style="color: #FF5252;">{{ user_error }}</p>
              </ValidationProvider>

              <ValidationProvider v-slot="{ errors }" name="Mật khẩu" rules="required|min:4|confirmed:confirmation">
                <v-text-field type="password" label="Mật khẩu" color="indigo lighten-1" dark outlined :error-messages="errors" required v-model="user.MatKhau"></v-text-field>
              </ValidationProvider>

              <ValidationProvider v-slot="{ errors }" vid="confirmation" name="Xác nhận mật khẩu" rules="required">
                <v-text-field type="password" label="Nhập lại mật khẩu" color="indigo lighten-1" dark outlined :error-messages="errors" required v-model="confirmation"></v-text-field>
              </ValidationProvider>

              <ValidationProvider v-slot="{ errors }" name="Email" rules="required|email">
                <v-text-field label="Email" color="indigo lighten-1" dark outlined :error-messages="errors" required v-model="user.Email"></v-text-field>
                <p v-if="email_error != ''" style="color: #FF5252;">{{ email_error }}</p>
              </ValidationProvider>

              <ValidationProvider v-slot="{ errors }" name="Số điện thoại" rules="required|numeric">
                <v-text-field label="Số điện thoại" color="indigo lighten-1" dark outlined :error-messages="errors" required v-model="user.SoDienThoai"></v-text-field>
              </ValidationProvider>
              <v-btn width="100%" height="55" color="indigo lighten-1" type="submit" dark><h3>Đăng ký</h3></v-btn>
              <v-btn class="mt-5" width="100%" height="55" color="red darken-3" dark @click="back"><h3>Quay lại</h3></v-btn>
              <div class="copyright">
                <p>© 2020 Classy Login Form. All rights reserved | Design by Hui</p>
              </div>
            </form>
          </ValidationObserver>
        </v-col>
        <v-col cols="4"></v-col>
      </v-row>
    </v-container>
  </v-app>
</template>
<script>
import axios from "axios";
import { required, email, numeric, min, confirmed } from "vee-validate/dist/rules";
import { extend, ValidationObserver, ValidationProvider } from "vee-validate";
var mess = "";
extend("required", {
  ...required,
  message: mess,
});

extend("min", {
  ...min,
  message: "{_field_} quán ngắn",
});

extend("email", {
  ...email,
  message: "Email không đúng định dạng",
});

extend("numeric", {
  ...numeric,
  message: "{_field_} phải là dạng số",
});

extend("confirmed", {
  ...confirmed,
  message: "Mật khẩu không trùng khớp",
});

export default {
  components: {
    ValidationObserver,
    ValidationProvider,
  },
  data: () => {
    return {
      user: {
        TaiKhoan: "",
        MatKhau: "",
        Email: "",
        SoDienThoai: "",
      },
      user_error: "",
      email_error: "",
      confirmation: "",
      errorUser: {
        TaiKhoan: "",
        Email: "",
      },
    };
  },

  methods: {
    addUser(user) {
      axios
        .post("https://localhost:44389/api/user", user)
        .then(() => {
          alert("Cập nhật thành công!");
          this.$router.push("/");
        })
        .catch((error) => {
          if (error.response) {
            error.response.data.forEach((val) => {
              if (this.user.TaiKhoan == val.taiKhoan) {
                this.user_error = "Tài khoản đã tồn tại!";
                this.mess = "Tài khoản đã tồn tại1!";
              }
              if (this.user.Email == val.email) {
                this.email_error = "Email đã tồn tại!";
              }
            });
          }
        });
    },

    onSubmit() {
      this.user_error = "";
      this.email_error = "";
      if (this.user.TaiKhoan != "" && this.user.MatKhau != "" && this.user.email != "" && this.user.SoDienThoai != "") {
        this.addUser(this.user);
      }
    },

    back() {
      this.$router.push("/");
    },
  },
};
</script>
