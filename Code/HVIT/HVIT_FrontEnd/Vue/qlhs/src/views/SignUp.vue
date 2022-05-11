<template>
  <v-app id="screen">
    <v-container fluid style="margin: auto 0;">
      <v-row>
        <v-col cols="4"></v-col>
        <v-col cols="4" class="frmLogin pt-10">
          <h1>
            B <span style="color: red;"><u>Í</u></span> T C O I
          </h1>
          <form class="px-11 mt-10">
            <ValidationObserver>
              <ValidationProvider v-slot="{ errors }" name="Tài khoản" rules="required">
                <v-text-field label="Tên đăng nhập" color="indigo lighten-1" dark outlined :error-messages="errors" required v-model="user.TaiKhoan"></v-text-field>
              </ValidationProvider>

              <ValidationProvider name="Mật khẩu" rules="required|password:@confirm" v-slot="{ errors }">
                <v-text-field type="password" label="Mật khẩu" color="indigo lighten-1" dark outlined :error-messages="errors" required v-model="user.MatKhau"></v-text-field>
              </ValidationProvider>

              <ValidationProvider v-slot="{ errors }" name="Mật khẩu" rules="required">
                <v-text-field type="password" label="Nhập lại khẩu" color="indigo lighten-1" dark outlined :error-messages="errors" required v-model="confirmation"></v-text-field>
              </ValidationProvider>

              <ValidationProvider v-slot="{ errors }" name="Email" rules="required|email">
                <v-text-field label="Email" color="indigo lighten-1" dark outlined :error-messages="errors" required v-model="user.Email"></v-text-field>
              </ValidationProvider>

              <ValidationProvider v-slot="{ errors }" name="Số điện thoại" rules="required|digits">
                <v-text-field label="Số điện thoại" color="indigo lighten-1" dark outlined :error-messages="errors" required v-model="user.SoDienThoai"></v-text-field>
              </ValidationProvider>
            </ValidationObserver>

            <v-btn width="100%" height="55" color="red darken-3" dark @click="signUp"><h3>Đăng ký</h3></v-btn>
            <div class="copyright">
              <p>© 2020 Classy Login Form. All rights reserved | Design by Hui</p>
            </div>
          </form>
        </v-col>
        <v-col cols="4"></v-col>
      </v-row>
    </v-container>
  </v-app>
</template>
<script>
import axios from "axios";
import { required, email, digits } from "vee-validate/dist/rules";
// import { extend, ValidationProvider, setInteractionMode } from "vee-validate";
import { extend, ValidationObserver, ValidationProvider, setInteractionMode } from "vee-validate";

setInteractionMode("eager");

extend("required", {
  ...required,
  message: "{_field_} không được để trống",
});

extend('password', {
  params: ['target'],
  validate(value, { target }) {
    return value === target;
  },
  message: 'Password confirmation does not match'
});
extend("email", {
  ...email,
  message: "Email không đúng định dạng",
});

extend("digits", {
  ...digits,
  message: "{_field_} phải là dạng số",
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
        userNameRules: [],
        MatKhau: "",
        Email: "",
        SoDienThoai: "",
      },
      confirmation: "",
    };
  },
  methods: {
    addUser(user) {
      axios.post("https://localhost:44389/api/user", user).then(() => {
        alert("Cập nhật thành công!");
      });
    },
    signUp() {
      // this.$refs.observer.validate();
      this.addUser(this.user);
    },
  },
};
</script>
