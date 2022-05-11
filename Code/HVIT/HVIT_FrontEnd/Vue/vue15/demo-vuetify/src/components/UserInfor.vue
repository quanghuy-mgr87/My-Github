<template>
  <v-container>
    <v-card max-width="600" height="500" class="mx-auto">
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="headline">User Profile</v-list-item-title>
        </v-list-item-content>
      </v-list-item>

      <v-data-table
        :headers="headers"
        :items="infor"
        :items-per-page="10"
        item-key="name"
        class="elevation-1"
        :footer-props="{
          showFirstLastPage: true,
          firstIcon: 'mdi-arrow-collapse-left',
          lastIcon: 'mdi-arrow-collapse-right',
          prevIcon: 'mdi-minus',
          nextIcon: 'mdi-plus',
        }"
      ></v-data-table>
    </v-card>
    <!--  -->
  </v-container>
</template>
<script>
import { eventBus } from "../main.js";
export default {
  data() {
    return {
      headers: [
        {
          text: "Name",
          align: "start",
          value: "name",
        },
        { text: "Data", value: "data" },
      ],
      infor: [
        {
          name: "Full Name",
          data: "",
        },
        {
          name: "Age",
          data: "",
        },
        {
          name: "Gentle",
          data: "",
        },
        {
          name: "Email",
          data: null,
        },
        {
          name: "Address",
          data: "",
        },
        {
          name: "Date of birth",
          data: null,
        },
        {
          name: "Introduce",
          data: "",
        },
      ],
    };
  },
  created() {
    eventBus.$on("userInfor", this.userInfor);
  },
  methods: {
    userInfor(val) {
      this.infor[0].data = val.fullName;
      this.infor[1].data = val.age;
      this.infor[2].data = val.gen;
      this.infor[3].data = val.email;
      this.infor[4].data = val.address;
      this.infor[5].data = val.dateFormatted;
      this.infor[6].data = val.introduce;
    },
  },
};
</script>
<style scoped></style>
