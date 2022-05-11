<template>
  <v-app id="screen">
    <v-container fluid style="margin: auto 0;">
      <v-row>
        <v-col cols="4"> </v-col>
        <v-col cols="4" class="frmLogin pt-10">
          <h1>
            <v-avatar tile size="60" class="mr-3 mb-2"> <v-img src="../logo/myLogo.png"></v-img> </v-avatar>
            <u> <span style="color: #1565C0">Y</span> <span style="color:#FF1744;">o</span> <span style="color:#76FF03;">U</span> </u>
          </h1>
          <ValidationObserver v-slot="{ handleSubmit }">
            <form @submit.prevent="handleSubmit(onSubmit)" class="px-11 mt-10">
              <ValidationProvider rules="required" name="Tài khoản" v-slot="{ errors }">
                <v-text-field :error-messages="errors" prepend-inner-icon="account_circle" label="Tên đăng nhập" color="indigo lighten-1" dark outlined v-model="user.taiKhoan"></v-text-field>
              </ValidationProvider>

              <ValidationProvider rules="required" name="Mật khẩu" v-slot="{ errors }">
                <v-text-field :error-messages="errors" type="password" prepend-inner-icon="lock" label="Mật khẩu" color="indigo lighten-1" dark outlined v-model="user.matKhau"></v-text-field>
              </ValidationProvider>
              <v-row>
                <v-col class="py-0" cols="6">
                  <v-checkbox color="indigo" label="Nhớ mật khẩu" dark></v-checkbox>
                </v-col>
                <v-col class="forgotPass py-5" cols="6">
                  <a href="#">Quên mật khẩu?</a>
                </v-col>
              </v-row>
              <p style="color: #FF5252;">{{ error }}</p>
              <v-btn width="100%" type="submit" height="55" color="indigo lighten-1" dark><h3>Đăng nhập</h3></v-btn>
              <v-btn class="mt-5" width="100%" height="55" color="red darken-3" to="/signUp" dark><h3>Đăng ký</h3></v-btn>

              <div style="text-align: center;" class="or mt-7 mb-4">
                <h3>or</h3>
              </div>
              <v-row class="mt-0">
                <v-col cols="6"
                  ><v-btn width="100%" height="40" color="info" dark> <v-icon class="mr-2">fab fa-facebook-square</v-icon> Facebook</v-btn></v-col
                >
                <v-col cols="6"
                  ><v-btn width="100%" height="40" color="red" dark><v-icon class="mr-2">fab fa-google-plus-square</v-icon>Google</v-btn></v-col
                >
              </v-row>
              <div class="copyright">
                <p>© 2020 Classy Login Form. All rights reserved | Design by Hui</p>
              </div>
            </form>
          </ValidationObserver>
        </v-col>
        <v-col cols="4"> </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>
<script>
import { ValidationProvider, ValidationObserver, extend } from "vee-validate";
import { required } from "vee-validate/dist/rules";
import { store } from "../store/index";
import axios from "axios";
import { eventBus } from "../main";
extend("required", {
  ...required,
  message: "{_field_} không được để trống",
});
export default {
  components: {
    ValidationProvider,
    ValidationObserver,
  },
  data: () => {
    return {
      user: {
        taiKhoan: "",
        matKhau: "",
        admin: 0,
      },
      link: "/",
      status: 0,
      error: "",
    };
  },

  methods: {
    checkUser(user) {
      axios
        .post("https://localhost:44389/api/user/checkUserPass", user)
        .then((response) => {
          store.commit("checkLog", true);
          store.commit("checkAdmin", response.data.quyenAdmin);
          this.admin = response.data.quyenAdmin;
          eventBus.$emit("checkAdmin", this.admin);
          eventBus.$emit("sendUsername", this.user.taiKhoan);
          this.$router.push("/home").catch(() => {});
        })
        .catch((error) => {
          if (error.response) {
            store.commit("checkLog", false);
            if (this.user.taiKhoan != "" && this.user.matKhau != "") {
              this.error = error.response.data;
            }
          }
        });
    },
    onSubmit() {
      this.checkUser(this.user);
    },
  },
};
</script>
<style>
#screen {
  background: url("https://images.pexels.com/photos/1749303/pexels-photo-1749303.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260") no-repeat center fixed;
  opacity: 0.98;
  filter: brightness(90%);
  background-size: cover;
}
.frmLogin {
  background-color: black;
  height: 100%;
  opacity: 0.95;
  color: white;
}
.frmLogin > h1 {
  text-align: center;
  font-size: 60px;
}
.forgotPass > a {
  font-size: 16px;
  text-decoration: none;
  color: white;
}
.forgotPass > a:hover {
  color: rgb(226, 92, 92);
}
.forgotPass {
  text-align: right;
}
.or > h3 {
  font-size: 22px;
  color: #fff;
  text-align: center;
  background: #ff3366;
  width: 40px;
  height: 40px;
  line-height: 1.7em;
  border-radius: 50%;
  margin: 0 auto;
}
.copyright {
  padding: 50px 0px;
  text-align: center;
}
.copyright > p {
  margin: auto 0;
}
</style>
