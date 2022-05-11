<template>
  <v-app id="screen">
    <v-container fluid style="margin: auto 0;">
      <v-row>
        <v-col cols="4"> </v-col>
        <v-col cols="4" class="frmLogin pt-10">
          <!-- <v-icon>fa fa-shopping-basket</v-icon> -->
          <h1>
            B <span style="color: red;"><u>Í</u></span> T C O I
          </h1>
          <form class="px-11 mt-10">
            <v-text-field prepend-inner-icon="account_circle" label="Tên đăng nhập" color="indigo lighten-1" dark outlined v-model="user.taiKhoan"></v-text-field>
            <v-text-field type="password" prepend-inner-icon="lock" label="Mật khẩu" color="indigo lighten-1" dark outlined v-model="user.matKhau"></v-text-field>
            <v-row>
              <v-col class="py-0" cols="6">
                <v-checkbox color="indigo" label="Nhớ mật khẩu" dark></v-checkbox>
              </v-col>
              <v-col class="forgotPass py-5" cols="6">
                <a href="#">Quên mật khẩu?</a>
              </v-col>
            </v-row>
            <p style="color: red;">{{ error }}</p>
            <v-btn width="100%" height="55" color="indigo lighten-1" dark @click="login"><h3>Đăng nhập</h3></v-btn>
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
            <!-- <v-btn @click="test">test</v-btn> -->
            <div class="copyright">
              <p>© 2020 Classy Login Form. All rights reserved | Design by Hui</p>
            </div>
          </form>
        </v-col>
        <v-col cols="4"> </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>
<script>
import axios from "axios";
import { store } from "../main";
export default {
  data: () => {
    return {
      user: {
        taiKhoan: "",
        matKhau: "",
      },
      link: "/",
      status: 0,
      error: "",
    };
  },

  // created() {
  //   store.commit("checkLogin", localStorage.getItem("state"));
  // },

  methods: {
    //axios
    CheckUserPass(user) {
      axios
        .post("https://localhost:44389/api/user/checkUserPass", user)
        .then(() => {
          store.commit("checkLogin", true);
          this.$router.push("/home");
        })
        .catch((error) => {
          if (error.response) {
            store.commit("checkLogin", false);
            this.error = error.response.data;
          }
        });
    },

    // test() {
    //   store.commit("checkLogin", true);
    //   console.log(store.state.check);
    // },

    login() {
      this.CheckUserPass(this.user);
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
