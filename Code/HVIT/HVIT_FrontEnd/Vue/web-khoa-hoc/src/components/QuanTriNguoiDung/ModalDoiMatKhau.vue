<template>
  <v-dialog max-width="450px" v-model="dialog">
    <ValidationObserver v-slot="{ handleSubmit }">
      <v-form @submit.prevent="handleSubmit(onSubmit)">
        <v-card>
          <v-card-title>
            <span class="headline"><b>Đổi mật khẩu</b></span>
          </v-card-title>
          <v-card-text>
            <ValidationProvider v-slot="{ errors }" name="Mật khẩu" rules="required|checkPass:">
              <v-text-field type="password" label="Mật khẩu cũ" color="indigo lighten-1" :error-messages="errors" required v-model="matKhauCu"></v-text-field>
            </ValidationProvider>

            <ValidationProvider v-slot="{ errors }" name="Mật khẩu mới" rules="required|min:4|confirmed:confirmation">
              <v-text-field type="password" label="Mật khẩu mới" color="indigo lighten-1" :error-messages="errors" required v-model="matKhauMoi"></v-text-field>
            </ValidationProvider>

            <ValidationProvider v-slot="{ errors }" vid="confirmation" name="Xác nhận mật khẩu" rules="required">
              <v-text-field type="password" label="Nhập lại mật khẩu" color="indigo lighten-1" :error-messages="errors" required v-model="confirmation"></v-text-field>
            </ValidationProvider>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn text type="submit" color="green"><b>Xác nhận</b></v-btn>
          </v-card-actions>
        </v-card>
      </v-form>
    </ValidationObserver>
  </v-dialog>
</template>
<script>
import { eventBus } from "../../main";
import { required, min, confirmed } from "vee-validate/dist/rules";
import { extend, ValidationObserver, ValidationProvider } from "vee-validate";

extend("required", {
  ...required,
  message: "{_field_} không được để trống",
});

extend("min", {
  ...min,
  message: "{_field_} quán ngắn",
});

extend("confirmed", {
  ...confirmed,
  message: "Mật khẩu không trùng khớp",
});

extend("checkPass", {
  validate(value, args) {
    return args.pass1 == args.pass2;
  },
  params: ["pass1", "pass2"],
  message: "Mật khẩu không trùng khớp",
});

export default {
  components: {
    ValidationObserver,
    ValidationProvider,
  },
  data() {
    return {
      dialog: false,
      matKhauCu: "",
      matKhauMoi: "",
      confirmation: "",
      test: "abc",
    };
  },
  created() {
    eventBus.$on("openChangePassDialog", this.openChangePassDialog);
  },
  methods: {
    openChangePassDialog(val) {
      this.dialog = val;
    },

    onSubmit() {
      console.log("test");
    },
  },
};
</script>
