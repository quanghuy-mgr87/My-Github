<template>
  <div>
    <div class="row">
      <div class="col-lg-4" :style="`text-align: center; background-color: ${turnOn ? 'white' : 'lightgrey'}`">
        <v-icon size="80" :style="`color: ${turnOn ? 'yellow' : 'grey'}`">
          mdi-lightbulb
        </v-icon>
        <br />
        <v-btn outlined color="brown" @click="lightSwitch()" style="margin-top: 10px; color: gray;">Turn {{ turnOn ? "off" : "on" }}</v-btn>
      </div>
      <div class="col-lg-4" style="background-color: lightgrey">
        <h5>Object Information:</h5>
        <h6>Name:</h6>
        <b> {{ user.name }}</b>
        <br />
        <h6>Age:</h6>
        <b> {{ user.age }}</b>
        <br />
        <h6>{{ user.name }} count</h6>
        <b style="font-size: 20px;"> {{ count }} </b>
        <h6>times</h6>
        <br />
        <second-component :name="user.name" :gen="user.gen" @nameChanged="updateUser"></second-component>
        <third-component :age="user.age"></third-component>
        <div style="text-align: center;">
          <v-btn id="btn" @click="onClick()">{{ user.name }} count</v-btn>
        </div>
      </div>
      <div class="col-lg-4" style="background-color: lightgrey">
        <h5 style="display: inline;">About {{ user.name }}:</h5>
        <br />
        <h6>Name:</h6>
        <b> {{ user.name }}</b>
        <br />
        <h6>Age:</h6>
        <b> {{ user.age }}</b>
        <br />
        <h6>Gen:</h6>
        <b> {{ user.gen }}</b>
        <br />
        <h6>Address:</h6>
        <b> {{ user.address }}</b>
      </div>
    </div>
    <!-- <div class="row">
      <div class="col-lg-4"></div>
      <div class="col-lg-4"></div>
      <div class="col-lg-4"></div>
    </div> -->
  </div>
</template>
<script>
import SecondComponent from "./SecondComponent";
import ThirdComponent from "./ThirdComponent";
import { eventBus } from "../main.js";
export default {
  data: function() {
    return {
      user: {
        name: "Ellie",
        age: 20,
        gen: "Female",
        address: "Los",
      },
      count: 0,
      turnOn: false,
    };
  },
  name: "firstComponent",
  components: {
    SecondComponent,
    ThirdComponent,
  },
  created() {
    eventBus.$on("ageChanged", this.ageChanged);
  },
  watch: {
    count() {
      this.count > 100 ? alert(this.user.name + ' said: "Bấm ít thôi hỏng chuột bậy giờ :))"') : "";
      this.count > 100 ? (this.turnOn = true) : (this.turnOn = false);
    },
  },
  methods: {
    updateUser(newName, newGen) {
      this.user.name = newName;
      this.user.gen = newGen;
    },
    ageChanged(val) {
      this.user.age = val;
    },
    onClick() {
      this.count += Math.floor(Math.random() * 10) + 1;
    },
    lightSwitch() {
      this.turnOn = !this.turnOn;
    },
  },
};
</script>
<style scoped>
.col-lg-4 {
  border: 1px solid green;
}
h6 {
  display: inline;
}
b {
  color: blueviolet;
}
#btn {
  color: tomato;
  margin-top: 10px;
}
</style>
