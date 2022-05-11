<template>
  <v-container>
    <v-card max-width="344" class="mx-auto">
      <v-list-item>
        <v-list-item-avatar color="grey">
          <v-img src="https://cdn.vuetifyjs.com/images/cards/mountain.jpg" height="194"></v-img>
        </v-list-item-avatar>
        <v-list-item-content>
          <v-list-item-title class="headline">Our Changing Planet</v-list-item-title>
          <v-list-item-subtitle>by Kurt Wagner</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-carousel height="200" show-arrows-on-hover>
        <v-carousel-item v-for="(item, i) in items" :key="i" :src="item.src"></v-carousel-item>
      </v-carousel>

      <v-card-text>
        Visit ten places on our planet that are undergoing the biggest changes today.
      </v-card-text>

      <v-card-actions>
        <v-btn text color="deep-purple accent-4">
          Read
        </v-btn>
        <v-btn text color="deep-purple accent-4">
          Bookmark
        </v-btn>
        <v-spacer></v-spacer>
        <v-btn icon @click="isRed = !isRed">
          <v-icon :style="`color: ${isRed ? 'red' : 'grey'}`">fas fa-heart</v-icon>
        </v-btn>
        <v-btn icon>
          <v-icon color="blue">fas fa-share</v-icon>
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      isRed: false,
      items: [
        {
          src: "https://cdn.vuetifyjs.com/images/cards/mountain.jpg",
        },
        {
          src: "https://cdn.vuetifyjs.com/images/carousel/squirrel.jpg",
        },
        {
          src: "https://cdn.vuetifyjs.com/images/carousel/sky.jpg",
        },
        {
          src: "https://cdn.vuetifyjs.com/images/carousel/bird.jpg",
        },
        {
          src: "https://cdn.vuetifyjs.com/images/carousel/planet.jpg",
        },
      ],
    };
  },
};
</script>
